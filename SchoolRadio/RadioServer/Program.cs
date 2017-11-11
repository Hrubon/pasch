using System;
using System.ServiceProcess;

using Settings = RadioServer.Properties.Settings;


namespace RadioServer
{
    public static class Program
    {
        static void InitLog()
        {
            var settings = Settings.Default;
            var log = new LogOutput(settings.LOG_FILE, settings.LOG_INFO, settings.LOG_WARNING, settings.LOG_ERROR);

            ProgramOutput.RegisterOutput(log);
        }


        static void EnableConsole()
        {
            var console = new ConsoleOutput();
            ProgramOutput.RegisterOutput(console);
        }



        static void Main(string[] args)
        {
            Console.WriteLine("--- Radio Server, version 1.0 ---\r\n");

            InitLog();

            // If option in valid format present...
            if (args != null && args.Length == 1 && args[0].Length > 1
                && (args[0][0] == '-' || args[0][0] == '/'))
            {
                // Parse option string
                switch (args[0].Substring(1).ToLower())
                {
                    case "c":
                    case "console":
                        Console.WriteLine("Starting in console mode... Press any key for exit.");
                        EnableConsole();
                        Server.Run();
                        Console.ReadKey(true);
                        Server.Abort();
                        break;
                    case "i":
                    case "install":
                        SelfInstaller.InstallMe();
                        break;
                    case "u":
                    case "uninstall":
                        SelfInstaller.UninstallMe();
                        break;
                    default:
                        Console.WriteLine("Invalid option! Exiting...");
                        Console.WriteLine(Settings.Default.PROGRAM_USAGE);
                        break;
                }
            }
            else
            {
                // No option present (or invalid format), running as Win Service...
                Console.WriteLine("Starting in service mode... For regular start see:");
                Console.WriteLine(Settings.Default.PROGRAM_USAGE);
                var winService = new[] { new WinService() };
                ServiceBase.Run(winService);
            }
        }
    }
}