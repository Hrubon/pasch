using System;
using System.IO;
using System.Windows.Forms;

using NAudio.Wave;


namespace RadioClient
{
    public partial class CalendarForm : Form
    {
        RequestSender client;
        User currentUser;



        private DateTime StartTime
        {
            get
            {
                return dtpDate.Value.Date.Add(dtpTime.Value.TimeOfDay);
            }
        }



        public BroadcastInfo Selected
        {
            get
            {
                return tlCalendar.SelectedTask.Task;
            }
        }



        private void CheckPermissions()
        {
            var perms = new[] { Permission.AdminBroadcasts };
            var request = new ListPermissionsRequset(currentUser, perms);
            var response = client.SendAndRecieve<ListPermissionsResponse>(request);
            if (response != null)
            {
                if (response.ContainsPermission(Permission.AdminBroadcasts))
                {
                    gbTargetDateTime.Visible = true;
                    tlCalendar.ReadOnly = false;
                    btnDeleteBroadcast.Visible = true;
                    btnSave.Visible = true;
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


        private void RefreshControls()
        {
            btnSave.Enabled = btnDeleteBroadcast.Enabled = gbTargetDateTime.Enabled = !tlCalendar.IsSelectionEmpty;
        }



        private void CalendarForm_Load(object sender, EventArgs e)
        {
            CheckPermissions();
            tlCalendar.StartTime = dtpTime.Value = dtpDate.Value = DateTime.Now;
            LoadCalendar();
        }


        private void tlCalendar_SelectionChanged(TimeLineTask selected, bool isEmpty)
        {
            if (!isEmpty)
                LoadBroadcast(selected.Task);

            RefreshControls();
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            var editRequest = new EditBroadcasRequest(currentUser, Selected.Id, StartTime, txtDescription.Text);
            var editResponse = client.SendAndRecieve<AlterBroadcastResponse>(editRequest);
            if (editResponse == null)
                return;

            if (editResponse.Result == AlterBroadcastResult.NotFound)
            {
                MessageBox.Show("Vámi zvolené hlášení bylo již odstraněno. Nyní bude kalendář aktualizován.", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                LoadCalendar();
                tlCalendar.ClearSelection();
                RefreshControls();
                return;
            }

            LoadCalendar();
            tlCalendar.ClearSelection();
            RefreshControls();
        }


        private void btnDeleteBroadcast_Click(object sender, EventArgs e)
        {
            var removeRequest = new RemoveBroadcasRequest(currentUser, Selected);
            var removeResponse = client.SendAndRecieve<AlterBroadcastResponse>(removeRequest);
            if (removeResponse == null)
                return;

            if (removeResponse.Result == AlterBroadcastResult.NotFound)
            {
                MessageBox.Show("Vámi zvolené hlášení bylo již odstraněno. Nyní bude kalendář aktualizován.", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                LoadCalendar();
                tlCalendar.ClearSelection();
                RefreshControls();
                return;
            }

            LoadCalendar();
            tlCalendar.ClearSelection();
            RefreshControls();
        }



        public CalendarForm()
        {
            InitializeComponent();
            client = MasterContainer.GetService<RequestSender>();
            currentUser = MasterContainer.GetService<User>();
        }
    }
}
