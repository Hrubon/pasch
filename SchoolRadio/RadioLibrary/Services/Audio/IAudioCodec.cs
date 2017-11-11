using NAudio.Wave;


public interface IAudioCodec
{
    string DisplayName { get; }
    WaveFormat RecordFormat { get; }
    int BitsPerSecond { get; }



    byte[] Encode(byte[] data, int offset, int length);
    byte[] Decode(byte[] data, int offset, int length);
}