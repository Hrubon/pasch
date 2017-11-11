using System;
using System.IO;
using System.Text;


public static class TcpProtocol
{
    private const string
        STARTER = "%STARTOFMESSAGE%",
        TERMINATOR = "%ENDOFMESSAGE%";

    private static readonly int MESSAGE_MIN_LENGTH = 4 + STARTER.Length + TERMINATOR.Length;



    public static byte[] FrameMessage(byte[] message)
    {
        byte[] framedMessage = new byte[4 + message.Length];
        var len = BitConverter.GetBytes(message.Length);
        Array.Copy(len, framedMessage, 4);
        Array.Copy(message, 0, framedMessage, 4, message.Length);

        return framedMessage;
    }


    public static int GetLength(Stream stream)
    {
        byte[] len = new byte[4];
        int read = stream.Read(len, 0, len.Length);
        if (read != 4)
            return -1;

        return BitConverter.ToInt32(len, 0);
    }



    private static bool HasStarter(Stream stream)
    {
        byte[] starter = new byte[STARTER.Length];
        int read = stream.Read(starter, 4, starter.Length);
        if (read != starter.Length)
            return false;

        return (Encoding.ASCII.GetString(starter) == STARTER);
    }

    private static bool HasTerminator(Stream stream)
    {
        byte[] terminator = new byte[TERMINATOR.Length];
        int read = stream.Read(terminator, (int)(stream.Length - terminator.Length), terminator.Length);
        if (read != terminator.Length)
            return false;

        return (Encoding.ASCII.GetString(terminator) == TERMINATOR);
    }
}