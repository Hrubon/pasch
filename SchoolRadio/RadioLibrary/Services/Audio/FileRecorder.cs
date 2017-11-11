using NAudio.Wave;


public class FileRecorder
{
    WaveIn waveIn;
    WaveFileWriter writer;
    BufferedWaveProvider buffer;
    IAudioCodec codec;
    int devNumber;


    public bool Recording { get; private set; }
    public IWaveProvider Audio {get { return buffer; }}



    public void Record(string path)
    {
        waveIn.StartRecording();
        Recording = true;
        writer = new WaveFileWriter(path, codec.RecordFormat);
    }


    public void Stop()
    {
        if (Recording)
        {
            waveIn.StopRecording();
            writer.Close();
            Recording = false;
        }
    }


    private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
    {
        var data = codec.Encode(e.Buffer, 0, e.BytesRecorded);
        buffer.AddSamples(data, 0, data.Length);
        writer.Write(data, 0, data.Length);
    }




    public FileRecorder(IAudioCodec codec, int devNumber)
    {
        this.codec = codec;
        this.devNumber = devNumber;

        waveIn = new WaveIn();
        waveIn.DeviceNumber = devNumber;
        waveIn.WaveFormat = codec.RecordFormat;
        waveIn.DataAvailable += WaveIn_DataAvailable;

        buffer = new BufferedWaveProvider(codec.RecordFormat);
    }
}