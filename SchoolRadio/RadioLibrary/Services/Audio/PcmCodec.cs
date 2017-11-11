using System;

using NAudio.Wave;


[Serializable]
public class PcmCodec : IAudioCodec
{
    public WaveFormat RecordFormat
    {
        get;
        private set;
    }


    public int BitsPerSecond
    {
        get
        {
            return RecordFormat.AverageBytesPerSecond * 8;
        }
    }

    public string DisplayName
    {
        get
        {
            return "Nekomprimované PCM";
        }
    }



    public byte[] Encode(byte[] data, int offset, int length)
    {
        var encoded = new byte[length];
        Array.Copy(data, offset, encoded, 0, length);
        return encoded;
    }


    public byte[] Decode(byte[] data, int offset, int length)
    {
        var decoded = new byte[length];
        Array.Copy(data, offset, decoded, 0, length);
        return decoded;
    }



    public PcmCodec()
    {
        RecordFormat = new WaveFormat(48000, 16, 1);
    }
}