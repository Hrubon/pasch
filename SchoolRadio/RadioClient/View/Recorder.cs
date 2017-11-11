using System;
using System.Drawing;
using System.Windows.Forms;

using NAudio.Wave;
using NAudio.Mixer;
using NAudio.Wave.SampleProviders;


namespace RadioClient
{
    public partial class Recorder : UserControl
    {
        WaveIn input;
        IAudioCodec codec;
        BufferedWaveProvider buffer;
        WaveOut output;
        SampleChannel channel;



        public event EventHandler ErrorAction;
        public event EventHandler<WaveInEventArgs> DataAvailable;



        public bool Recording { get; private set; }
        public int SelectedDevice
        {
            get
            {
                return cbInput.SelectedIndex;
            }
        }
        public int InputBufferMilisec
        {
            get
            {
                if (input != null)
                    return input.BufferMilliseconds;
                return -1;
            }
            set
            {
                if (input != null)
                {
                    input.BufferMilliseconds = value;
                    buffer.BufferDuration = new TimeSpan(0, 0, 0, 0, input.BufferMilliseconds * 6);
                }
            }
        }
        public int RecordingVolume
        {
            get
            {
                return tbVolume.Value;
            }
        }
        public bool Ready { get; private set; }
        public int FeedbackVolume
        {
            get
            {
                return (chbFeedback.Checked) ? 1 : 0;
            }
        }
        Color frontColor;
        public Color FrontColor
        {
            get
            {
                return frontColor;
            }
            set
            {
                frontColor = value;
                vmLevel.ForeColor = frontColor;
                tbTime.ForeColor = frontColor;
                wfpLevel.ForeColor = frontColor;
            }
        }
        Color fillColor;
        public Color FillColor
        {
            get
            {
                return fillColor;
            }
            set
            {
                fillColor = value;
                vmLevel.BackColor = fillColor;
                tbTime.BackColor = fillColor;
                wfpLevel.BackColor = fillColor;
            }
        }




        private void LoadInputDevs()
        {
            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                var device = WaveIn.GetCapabilities(i);
                cbInput.Items.Add(device.ProductName);
            }
            if (cbInput.Items.Count > 0)
                cbInput.SelectedIndex = 0;
            else
            {
                MessageBox.Show("Nebyla nalezena žádná zvuková vstupní zařízení.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                if (ErrorAction != null)
                    ErrorAction(this, new EventArgs());
            }
        }


        private void SetRecordingVolume()
        {
            int waveInDeviceNumber = 0;
            var mixerLine = new MixerLine((IntPtr)waveInDeviceNumber,
                                           0, MixerFlags.WaveIn);
            foreach (var control in mixerLine.Controls)
            {
                if (control.ControlType == MixerControlType.Volume)
                {
                    var volumeControl = control as UnsignedMixerControl;
                    volumeControl.Percent = RecordingVolume;
                    break;
                }
            }
        }


        private void ResetPainter()
        {
            gbWaveform.Controls.Remove(wfpLevel);
            wfpLevel = new NAudio.Gui.WaveformPainter();
            wfpLevel.Dock = DockStyle.Fill;
            wfpLevel.ForeColor = FrontColor;
            wfpLevel.BackColor = FillColor;
            gbWaveform.Controls.Add(wfpLevel);
        }



        public void Init(IAudioCodec codec)
        {
            this.codec = codec;
            
            // Init record input
            input = new WaveIn();
            input.DeviceNumber = cbInput.SelectedIndex;
            input.WaveFormat = codec.RecordFormat;
            input.DataAvailable += Input_DataAvailable;
            input.StartRecording();

            // Init buffer - level meters will use it
            buffer = new BufferedWaveProvider(codec.RecordFormat);
            InputBufferMilisec = 50;

            // Init level meters
            channel = new SampleChannel(buffer, true);
            var meter = new MeteringSampleProvider(channel);
            meter.StreamVolume += Meter_StreamVolume;

            // Init feedback output
            output = new WaveOut();
            output.Volume = FeedbackVolume;
            output.Init(meter);
            output.Play();

            Ready = true;
        }


        public void Record()
        {
            ResetPainter();
            if (!Recording)
                channel.PreVolumeMeter += Channel_PreVolumeMeter;

            tbTime.Reset();
            tbTime.Start();
            Recording = true;
            gbInput.Enabled = false;
        }


        public void Stop()
        {
            if (Recording)
                channel.PreVolumeMeter -= Channel_PreVolumeMeter;

            tbTime.Stop();
            Recording = false;
            gbInput.Enabled = true;
        }


        public void Close()
        {
            Stop();
            input.StopRecording();
            output.Stop();
            vmLevel.Amplitude = 0;
        }


        public void Open()
        {
            Init(codec);
        }


        private void Input_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (buffer.BufferedBytes + e.BytesRecorded <= buffer.BufferLength)
                buffer.AddSamples(e.Buffer, 0, e.BytesRecorded);
            if (DataAvailable != null && Recording)
                DataAvailable(this, e);
        }



        private void Recorder_Load(object sender, EventArgs e)
        {
            LoadInputDevs();
        }


        private void cbInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (input != null)
            {
                input.DeviceNumber = cbInput.SelectedIndex;
                input.StopRecording();
                input.StartRecording();
            }
        }


        private void chbFeedback_CheckedChanged(object sender, EventArgs e)
        {
            if (output != null)
                output.Volume = FeedbackVolume;
        }


        private void tbVolume_Scroll(object sender, EventArgs e)
        {
            SetRecordingVolume();
        }


        private void Meter_StreamVolume(object sender, StreamVolumeEventArgs e)
        {
            vmLevel.Amplitude = e.MaxSampleValues[0];
        }


        private void Channel_PreVolumeMeter(object sender, StreamVolumeEventArgs e)
        {
            wfpLevel.AddMax(e.MaxSampleValues[0]);
        }


        public Recorder()
        {
            InitializeComponent();
        }
    }
}
