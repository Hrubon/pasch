using System;


namespace RadioClient
{
    public class TimeLineTask
    {
        public BroadcastInfo Task { get; private set; }

        public int XStart { get; set; }
        public int XEnd { get; set; }



        public TimeLineTask(BroadcastInfo task)
        {
            Task = task;
            XStart = 0;
            XEnd = 0;
        }
    }
}