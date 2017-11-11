using System;

using NAudio.Wave;


public class Playback
{
    const string WAV_EXT = ".wav",
                 MP3_EXT = ".mp3";



    WaveOut waveOut;



    public int OutputsCount
    {
        get
        {
            return WaveOut.DeviceCount;
        }
    }



    public int OutDevNumber { get; private set; }
    public string OutName
    {
        get
        {
            return WaveOut.GetCapabilities(OutDevNumber).ProductName;
        }
    }
    public bool Playing
    {
        get
        {
            return (waveOut == null) ? false : (waveOut.PlaybackState == PlaybackState.Playing);
        }
    }



    private void Play(IWaveProvider input)
    {
        waveOut.Init(input);
        waveOut.Play();
    }



    public void Start(IWaveProvider input)
    {
        Play(input);
    }


    public void Start(string fileName)
    {
        WaveStream stream;
        if (fileName.EndsWith(WAV_EXT))
            stream = new WaveFileReader(fileName);
        else if (fileName.EndsWith(MP3_EXT))
            stream = new Mp3FileReader(fileName);
        else
            throw new Exception("Unsupported file format.");

        Start(stream);
    }


    public void Stop()
    {
        waveOut.Stop();
        waveOut.Dispose();
    }



    public Playback(int outDevNumber)
    {
        OutDevNumber = outDevNumber;
        waveOut = new WaveOut();
        waveOut.DeviceNumber = OutDevNumber;
    }
}