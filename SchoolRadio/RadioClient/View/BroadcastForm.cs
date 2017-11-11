using System;
using System.IO;
using System.Windows.Forms;

using NAudio.Wave;

using Settings = RadioClient.Properties.Settings;


namespace RadioClient
{
    public partial class BroadcastForm : Form
    {
        RequestSender client;
        User currentUser;
        RecordForm recForm;



        private DateTime StartTime
        {
            get
            {
                return dtpDate.Value.Date.Add(dtpTime.Value.TimeOfDay);
            }
        }
        private BroadcastType BroadcastType
        {
            get
            {
                if (rbRecordNew.Checked || rbFromFile.Checked)
                    return BroadcastType.File;
                else if (rbLiveBroadcast.Checked)
                    return BroadcastType.Reservation;
                else
                    return BroadcastType.Reservation;
            }
        }
        public MediaType MediaType
        {
            get
            {
                if (rbRecordNew.Checked)
                    return MediaType.WAV;
                else if (rbFromFile.Checked)
                    return MediaType.MP3;
                else
                    return MediaType.Other;
            }
        }


        public bool ShowRecOnLoad { get; set; }
        public BroadcastInfo Selected
        {
            get
            {
                return tlCalendar.SelectedTask.Task;
            }
        }



        private void SetEditMode()
        {
            this.Text = "Naplánovat hlášení";
            gbSource.Enabled = true;
            gbTargetDateTime.Enabled = true;
            tlCalendar.ReadOnly = true;
            tlCalendar.StartTime = dtpTime.Value = dtpDate.Value = DateTime.Now;
        }


        private void CheckPermissions()
        {
            var perms = new[] { Permission.PlanBroadcasts, Permission.LiveBroadcast };
            var request = new ListPermissionsRequset(currentUser, perms);
            var response = client.SendAndRecieve<ListPermissionsResponse>(request);
            if (response != null)
            {
                if (!response.ContainsPermission(Permission.LiveBroadcast) &&
                    !response.ContainsPermission(Permission.PlanBroadcasts))
                {
                    MessageBox.Show("Nemáte oprávnění plánovat žádná hlášení.");
                    this.Close();
                }
                if (response.ContainsPermission(Permission.LiveBroadcast))
                {
                    rbLiveBroadcast.Enabled = true;
                    rbLiveBroadcast.Checked = true;
                }
                if (response.ContainsPermission(Permission.PlanBroadcasts))
                {
                    rbRecordNew.Enabled = rbFromFile.Enabled = true;
                    rbRecordNew.Checked = true;
                }
            }
            else
                this.Close();
        }


        private void LoadCalendar()
        {
            var oneDay = new TimeSpan(1, 0, 0, 0, 0);
            var request = new SelectBroadcastRequest(
                currentUser, DateTime.Now.Subtract(oneDay), DateTime.Now.Add(oneDay));//tlCalendar.StartTime, tlCalendar.EndTime);

            var response = client.SendAndRecieve<SelectBroadcastResponse>(request);
            if (response != null)
            {
                tlCalendar.SetTasks(response.Broadcasts);
            }
            else
                this.Close();
        }

        private void LoadBroadcast(BroadcastInfo broadcast)
        {
            txtDescription.Text = broadcast.Label;
            dtpDate.Value = broadcast.StartTime.Date;
            dtpTime.Value = broadcast.StartTime;
        }



        private void CalendarForm_Load(object sender, EventArgs e)
        {
            if (ShowRecOnLoad)
                recForm.ShowDialog();

            SetEditMode();
            CheckPermissions();
            LoadCalendar();
        }


        private void rbRecordNew_CheckedChanged(object sender, EventArgs e)
        {
            btnRecord.Enabled = rbRecordNew.Checked;
        }


        private void btnRecord_Click(object sender, EventArgs e)
        {
            recForm.ShowDialog();
        }


        private void rbFromFile_CheckedChanged(object sender, EventArgs e)
        {
            txtFilePath.Enabled = btnBrowse.Enabled = rbFromFile.Checked;
        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            ofdBrowseAudioFile.ShowDialog();
            txtFilePath.Text = ofdBrowseAudioFile.FileName;
        }


        private void rbLiveBroadcast_CheckedChanged(object sender, EventArgs e)
        {
            lbDuration.Enabled = dtpDuration.Enabled = rbLiveBroadcast.Checked;
        }



        private string GetFilename()
        {
            if (rbRecordNew.Checked)
            {
                if (recForm.FilePath == null)
                {
                    MessageBox.Show("Zatím nebyla nahrána žádná stopa. Prosím stiskněte tlačítko 'nahrát'.", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
                if (!File.Exists(recForm.FilePath))
                {
                    MessageBox.Show("Nahraný soubor nebyl nalezen. Prosím nahrajte soubor znovu.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                return recForm.FilePath;
            }
            if (rbFromFile.Checked)
            {
                if (!File.Exists(txtFilePath.Text))
                {
                    MessageBox.Show("Vámi zvolený soubor nebyl nalezen.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                return txtFilePath.Text;
            }
            else
                return string.Empty;
        }


        private void NewBroadcast()
        {
            AudioFileReader reader;
            var file = GetFilename();
            if (file == null)
                return;
            else
                reader = new AudioFileReader(file);

            var duration = (rbLiveBroadcast.Checked) ? dtpDuration.Value.TimeOfDay : reader.TotalTime;

            var broadcast = new BroadcastInfo(currentUser.Username, StartTime, duration, BroadcastType, MediaType, txtDescription.Text);
            var planRequest = new PlanBroadcastRequest(currentUser, broadcast);
            var planResponse = client.SendAndRecieve<PlanBroadcastResponse>(planRequest);
            if (planRequest != null)
            {
                switch (planResponse.Result)
                {
                    case PlanBroadcastResult.CanUpload:
                        break;
                    case PlanBroadcastResult.CannotUpload:
                        MessageBox.Show("Hlášení koliduje s jiným(i) hlášením(i), zvolte, prosím, jiný čas.");
                        return;
                    case PlanBroadcastResult.CanUploadIfAdmin:
                        var result = MessageBox.Show("Hlášení koliduje s jiným(i) hlášením(i), chcete tato hlášení odstranit?", "Otázka", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                            break;
                        else
                            return;
                }
            }
            else
                return;

            if (!rbLiveBroadcast.Checked)
            {
                var settings = Settings.Default;
                var uploadRequest = new UploadBroadcastRequest(currentUser, broadcast, MediaType.MP3, settings.BROADCAST_PORT, settings.TRANSFER_BUFFER_SIZE); //TODO: Media file detection
                var uploadResponse = client.SendAndRecieve<UploadBroadcastResponse>(uploadRequest);
                if (uploadResponse != null)
                {
                    switch (uploadResponse.Result)
                    {
                        case UploadBroadcastResult.Success:
                            FileStreamer streamer = new FileStreamer(file, settings.TRANSFER_BUFFER_SIZE, settings.SERVER_IP, settings.BROADCAST_PORT); //TODO: From settings...
                            streamer.Start();
                            MessageBox.Show("Vaše hlášení bylo úspěšně naplánováno.", "Oznámení", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                            break;
                        case UploadBroadcastResult.CollissionBlocked:
                            MessageBox.Show("Hlášení koliduje s jiným(i) hlášením(i), zvolte, prosím, jiný čas.", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                    }
                }
                else
                    return;
            }
        }


        private bool RemoveSelectedBroadcast()
        {
            var removeRequest = new RemoveBroadcasRequest(currentUser, Selected);
            var removeResponse = client.SendAndRecieve<AlterBroadcastResponse>(removeRequest);
            if (removeResponse == null)
                return false;

            if (removeResponse.Result == AlterBroadcastResult.NotFound)
            {
                MessageBox.Show("Vámi zvolené hlášení bylo již odstraněno. Nyní bude kalendář aktualizován.", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                LoadCalendar();
                return false;
            }

            return true;
        }



        private void btnDeleteBroadcast_Click(object sender, EventArgs e)
        {
            RemoveSelectedBroadcast();
            LoadCalendar();
        }


        private void btnApply_Click(object sender, EventArgs e)
        {
            if (RemoveSelectedBroadcast())
            {
                NewBroadcast();
                LoadCalendar();
            }
        }


        private void btnAccept_Click(object sender, EventArgs e)
        {
            NewBroadcast();
            //this.Close();
        }



        public BroadcastForm()
        {
            InitializeComponent();
            client = MasterContainer.GetService<RequestSender>();
            currentUser = MasterContainer.GetService<User>();
            recForm = new RecordForm();
        }
    }
}
