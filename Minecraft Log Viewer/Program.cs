using System;
using System.Diagnostics;
using System.IO;
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
                Console.WriteLine("このプログラムを実行するには、Minecraftがインストールされている必要があります。");
                WaitForAnyKey();
                return;
            }

            string logsFolderPath = Path.Combine(minecraftFolderPath, "logs");
            if (!Directory.Exists(logsFolderPath))
            {
                Console.WriteLine("デフォルトのMinecraftフォルダーにlogsフォルダーが見つかりません。Minecraftがインストールされているかか、logsフォルダーが存在することを確認してください。");
                WaitForAnyKey();
                return;
            }

            Process[] minecraftProcesses = Process.GetProcessesByName("Minecraft");
            if (minecraftProcesses.Length == 0)
            {
                Console.WriteLine("このプログラムを実行するには、Minecraftが実行されている必要があります。Minecraftを実行してから再試行してください。");
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
                Console.WriteLine("指定されたフォルダーにはlatest.logがありません。ファイルのパスを確認してください。");
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
            Console.WriteLine(Environment.NewLine + "任意のキーを押してアプリケーションを終了します...");
            Console.ReadKey();
        }
    }
}