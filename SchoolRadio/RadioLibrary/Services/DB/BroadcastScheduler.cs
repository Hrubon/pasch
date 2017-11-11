using System;
using System.Timers;


public class BroadcastScheduler
{
    Timer timer;
    IBroadcastDatabase db;
    FileStore store;
    Playback playback;



    private void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        var broadcast = db.GetNowPlaying();
        if (broadcast != null && broadcast.Type == BroadcastType.File && !playback.Playing)
        {
            string filename = store.GetFullFilename(broadcast);
            ProgramOutput.Info("Starting playback: {0} ({1})...", broadcast.Filename, broadcast.Label);
            playback.Start(filename);
        }
    }



    public void StartChecking()
    {
        timer.Start();
    }


    public void StopChecking()
    {
        timer.Stop();
    }



    public BroadcastScheduler(IBroadcastDatabase db, FileStore store, Playback playback, int checkInterval)
    {
        timer = new Timer();
        timer.Interval = checkInterval;
        timer.Elapsed += Timer_Elapsed;

        this.db = db;
        this.store = store;
        this.playback = playback;

    }
}