using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

using Settings = RadioServer.Properties.Settings;


namespace RadioServer
{
    [RunInstaller(true)]
    public class WinServiceInstaller : Installer
    {
        public WinServiceInstaller()
        {
            var serviceProcessInstaller = new ServiceProcessInstaller();
            var serviceInstaller = new ServiceInstaller();

            // Run as LocalSystem
            serviceProcessInstaller.Account = ServiceAccount.LocalSystem;
            serviceProcessInstaller.Username = null;
            serviceProcessInstaller.Password = null;

            // Unique name, display name and description
            serviceInstaller.ServiceName = Settings.Default.SERVICE_NAME;
            serviceInstaller.DisplayName = Settings.Default.SERVICE_DISPLAYNAME;
            serviceInstaller.Description = Settings.Default.SERVICE_DESCRIPTION;

            // Start type
            serviceInstaller.StartType = ServiceStartMode.Automatic;

            this.Installers.Add(serviceProcessInstaller);
            this.Installers.Add(serviceInstaller);
        }
    }
}