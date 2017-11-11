using System;
using System.Drawing;
using System.Windows.Forms;

using NAudio.Wave;

using Settings = RadioClient.Properties.Settings;


namespace RadioClient
{
    public partial class LiveBroadcastForm : Form
    {
        LiveBroadcastStreamer streamer;
        IAudioCodec codec;



        private void OnRecord()
        {
            var settings = Settings.Default;

            var client = MasterContainer.GetService<RequestSender>();
            var currentUser = MasterContainer.GetService<User>();
            var request = new LiveBroadcastRequest(currentUser, settings.SERVER_IP, settings.BROADCAST_PORT);
            var response = client.SendAndRecieve<LiveBroadcastResponse>(request);

            string message = null;
            if (response != null)
            {
                if (response.Result == LiveBroadcastResults.Recieving)
                {
                    rcRecorder.FrontColor = Color.Red;
                    btnRecord.Enabled = false;

                    rcRecorder.Record();
                    streamer.StartStreaming();
                }
                else
                    message = string.Format("Pøi pokusu o navázání pøipojení došlo k následující chybì:\r\n\r\n{0}.",
                        response.Error);

            }
            else
                message = "Neznámá chyba";

            if (message != null)
                MessageBox.Show(message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void OnStop()
        {
            if (rcRecorder.Recording)
            {
                rcRecorder.Stop();
                streamer.StopStreaming();

                var client = MasterContainer.GetService<RequestSender>();
                var currentUser = MasterContainer.GetService<User>();
                var request = new StopLiveBroadcastRequest(currentUser);
                client.SendAndRecieve<StopLiveBroadcastResponse>(request);
            }
            rcRecorder.FrontColor = Color.Lime;
            btnRecord.Enabled = true;
        }



        private void RecordForm_Load(object sender, EventArgs e)
        {
            var settings = Settings.Default;

            codec = new PcmCodec(); // TODO: codec selection from settings
            rcRecorder.Init(codec);
            rcRecorder.DataAvailable += RcRecorder_DataAvailable;

            streamer = new LiveBroadcastStreamer(settings.SERVER_IP, settings.BROADCAST_PORT, codec);
        }


        private void RcRecorder_DataAvailable(object sender, WaveInEventArgs e)
        {
            streamer.waveIn_DataAvailable(sender, e);
        }


        private void btnRecord_Click(object sender, EventArgs e)
        {
            OnRecord();
        }


        private void btnStop_Click(object sender, EventArgs e)
        {
            OnStop();
        }


        private void RecordForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            rcRecorder.Close();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }



        public LiveBroadcastForm()
        {
            InitializeComponent();
        }
    }
}
