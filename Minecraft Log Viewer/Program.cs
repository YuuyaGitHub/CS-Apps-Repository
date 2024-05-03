using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace Minecraft_Log_Viewer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Minecraft Log Viewer";
            Console.Clear();

            string minecraftLogPath;

            string minecraftFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".minecraft");
            if (!Directory.Exists(minecraftFolderPath))
            {
                Console.WriteLine("Minecraft is not installed or the .minecraft folder is missing. Minecraft must be installed to use this program.");
                WaitForAnyKey();
                return;
            }

            string[] targetProcessNames = { "Minecraft", "javaw", "java" };
            Process[] minecraftProcesses = targetProcessNames.SelectMany(Process.GetProcessesByName).ToArray();

            if (minecraftProcesses.Length == 0)
            {
                Console.WriteLine("Minecraft must be running for this program to run. Please run Minecraft and try again.");
                WaitForAnyKey();
                return;
            }

            string logsFolderPath = Path.Combine(minecraftFolderPath, "logs");
            if (!Directory.Exists(logsFolderPath))
            {
                Console.WriteLine("I can't find the logs folder in the default Minecraft folder (.minecraft). Make sure Minecraft is installed or the logs folder exists.");
                WaitForAnyKey();
                return;
            }

            if (args.Length > 0 && args[0] == "/customfolder:" && args.Length > 1)
            {
                string customFolderPath = args[1];
                minecraftLogPath = Path.Combine(customFolderPath, "logs", "latest.log");
            }
            else
            {
                minecraftLogPath = Path.Combine(logsFolderPath, "latest.log");
            }

            if (!File.Exists(minecraftLogPath))
            {
                Console.WriteLine("latest.log does not exist in the specified location or is not in the Minecraft profile directory. Please check the location and try again.");
                WaitForAnyKey();
                return;
            }

            using (var fs = new FileStream(minecraftLogPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var sr = new StreamReader(fs))
            {
                Console.CancelKeyPress += (s, e) =>
                {
                    e.Cancel = true;
                };

                string line;
                while (true)
                {
                    line = sr.ReadLine();
                    if (line == null)
                    {
                        Thread.Sleep(1);
                    }
                    else
                    {
                        Console.WriteLine(line);
                    }
                }
            }
        }

        static void WaitForAnyKey()
        {
            Console.WriteLine(Environment.NewLine + "Press any key to exit the application...");
            Console.ReadKey();
        }
    }
}