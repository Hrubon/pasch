using System;


public abstract class Output
{
    public bool LogInfo { get; private set; }
    public bool LogWarning { get; private set; }
    public bool LogError { get; private set; }



    public void Info(string message, params object[] args)
    {
        if (LogInfo)
        {
            message = string.Format("{0}: {1}", DateTime.Now, message);
            Write(message, args);
        }
    }


    public void Warning(string message, params object[] args)
    {

        if (LogWarning)
        {
            message = string.Format("{0}: {1}", DateTime.Now, message);
            Write(message, args);
        }
    }


    public void Error(string message, params object[] args)
    {
        if (LogError)
        {
            message = string.Format("{0}: {1}", DateTime.Now, message);
            Write(message, args);
        }
    }



    public abstract void Write(string message, params object[] args);



    public Output(bool logInfo = true, bool logWarning = true, bool logError = true)
    {
        LogInfo = logInfo;
        LogWarning = logWarning;
        LogError = logError;
    }
}