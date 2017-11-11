using System;
using System.IO;
using System.ServiceProcess;


namespace RadioServer
{
    public partial class WinService : ServiceBase
    {
        protected override void OnStart(string[] args)
        {
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            Server.Run();
        }


        protected override void OnStop()
        {
            Server.Abort();
        }



        public WinService()
        {
            InitializeComponent();
        }
    }
}
