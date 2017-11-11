using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using NAudio.Wave;


namespace RadioClient
{
    public partial class RecordForm : Form
    {
        IAudioCodec codec;
        WaveFileWriter writer;
        AudioFileReader reader;
        WaveOut preview;



        public string FilePath { get; set; }
        public bool PlayingPreview { get; private set; }



        private void OnRecord()
        {
            string path = Path.GetTempFileName();
            writer = new WaveFileWriter(path, codec.RecordFormat);
            FilePath = path;
            rcRecorder.Record();

            preview.Stop();
            btnPausePlay.Enabled = false;
            rcRecorder.FrontColor = Color.Red;
        }


        private void OnStop()
        {
            if (rcRecorder.Recording)
            {
                rcRecorder.Stop();
                writer.Close();
            }
            else if (PlayingPreview)
            {
                PlayingPreview = false;
                preview.Stop();
                rcRecorder.Init(codec);
                btnPausePlay.Image = Properties.Resources.play;
            }
            btnRecord.Enabled = true;
            btnPausePlay.Enabled = File.Exists(FilePath);
            rcRecorder.FrontColor = Color.Lime;
        }


        private void OnPausePlay()
        {
            if (File.Exists(FilePath))
            {
                if (!PlayingPreview)
                {
                    // On Play
                    if (preview.PlaybackState == PlaybackState.Stopped)
                    {
                        // Init playback when transiting from stopped state
                        rcRecorder.Close();
                        reader = new AudioFileReader(FilePath);
                        preview.Init(reader);
                        preview.PlaybackStopped += Preview_PlaybackStopped;
                        preview.Volume = 1;
                        btnRecord.Enabled = false;
                    }

                    PlayingPreview = true;
                    preview.Play();
                    btnPausePlay.Image = Properties.Resources.pause;
                }
                else
                {
                    // On Pause
                    PlayingPreview = false;
                    preview.Pause();
                    btnPausePlay.Image = Properties.Resources.play;
                }
            }
        }



        private void RecordForm_Load(object sender, EventArgs e)
        {
            codec = new PcmCodec(); // TODO: codec selection from settings
            rcRecorder.Init(codec);
            rcRecorder.DataAvailable += RcRecorder_DataAvailable;

            preview = new WaveOut();
        }


        private void RcRecorder_DataAvailable(object sender, WaveInEventArgs e)
        {
            writer.Write(e.Buffer, 0, e.BytesRecorded);
        }


        private void btnRecord_Click(object sender, EventArgs e)
        {
            OnRecord();
        }


        private void btnStop_Click(object sender, EventArgs e)
        {
            OnStop();
        }


        private void btnPausePlay_Click(object sender, EventArgs e)
        {
            OnPausePlay();
        }


        private void Preview_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            OnStop();
        }


        private void RecordForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            rcRecorder.Close();
        }


        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            var result = sfdSaveAs.ShowDialog();
            if (result == DialogResult.OK)
            {
                File.Copy(FilePath, sfdSaveAs.FileName, true);
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            //this.Hide();
            this.Close();
        }



        public RecordForm()
        {
            InitializeComponent();
        }
    }
}
