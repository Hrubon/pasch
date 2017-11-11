using System;


[Serializable]
public class Session
{
    public string Host { get; private set; }
    public int Port { get; private set; }
    public string Endpoint
    {
        get
        {
            return string.Format("{0}:{1}", Host, Port);
        }
    }

    public EncryptionProvider Crpter { get; set; }
    public SessionPhase CurrentPhase { get; set; }

    private User user;
    public User User
    {
        get
        {
            return user;
        }
        set
        {
            if (user != null)
                user = value;
        }
    }



    public void NextPhase()
    {
        if (CurrentPhase != SessionPhase.Established)
            CurrentPhase++;
    }



    public Session(string host, int port)
    {
        Host = host;
        Port = port;
        Crpter = null;
        CurrentPhase = SessionPhase.Hello;
        user = null;
    }
}