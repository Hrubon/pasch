using System.Reflection;
using System.Configuration.Install;


namespace RadioServer
{
    class SelfInstaller
    {
        private static readonly string exePath = Assembly.GetExecutingAssembly().Location;



        public static bool InstallMe()
        {
            try
            {
                ManagedInstallerClass.InstallHelper(new string[] { exePath });
                return true;
            }
            catch
            {
                return false;
            }
        }


        public static bool UninstallMe()
        {
            try
            {
                ManagedInstallerClass.InstallHelper(new string[] { "/u", exePath });
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}