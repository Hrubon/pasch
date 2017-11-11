using System;
using System.Collections.Generic;


public class SessionManager
{
    List<Session> sessions;



    public IEnumerable<Session> GetSessions()
    {
        return sessions;
    }


    public Session GetSession(string hostname)
    {
        foreach (var session in sessions)
        {
            if (session.Host == hostname)
            {
                return session;
            }
        }
        return null;
    }


    public void AddSession(string host, int port)
    {
        AddSession(new Session(host, port));
    }


    public void AddSession(Session session)
    {
        RemoveSession(session);
        sessions.Add(session);
    }


    public void RemoveSession(Session session)
    {
        var existing = GetSession(session.Host);
        if (existing != null)
        {
            sessions.Remove(existing);
        }
    }



    public SessionManager()
    {
        sessions = new List<Session>();
    }
}