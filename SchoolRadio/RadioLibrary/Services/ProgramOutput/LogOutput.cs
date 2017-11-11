using System.IO;


public class LogOutput : Output
{
    public string LogFile { get; private set; }



    public override void Write(string message, params object[] args)
    {
        var msg = new[] { string.Format(message, args) };
        try
        {
            File.AppendAllLines(LogFile, msg);
        }
        catch { }
    }


    public LogOutput(string logFile, bool logInfo, bool logWarning, bool logError)
        : base(logInfo, logWarning, logError)
    {
        LogFile = logFile;
    }
}