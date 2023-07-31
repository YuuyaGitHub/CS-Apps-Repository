using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgumentsTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("引数が指定されていません");
            }
            else
            {
                if (Array.IndexOf(args, "/?") != -1)
                {
                    DisplayHelp();
                }
                else
                {
                    if (Array.IndexOf(args, "/s") != -1)
                    {
                        Console.WriteLine("あああ");
                    }

                    if (Array.IndexOf(args, "/k") != -1)
                    {
                        Console.WriteLine("任意のキーを押してください...");
                        Console.ReadKey();
                    }

                    if (Array.IndexOf(args, "/y") != -1)
                    {
                        System.Diagnostics.Process.Start("https://youtube.com/");
                        Console.WriteLine("YouTubeをブラウザで開きました。");
                    }

                    foreach (var arg in args)
                    {
                        if (arg.StartsWith("/name:"))
                        {
                            string name = arg.Substring(6);
                            Console.WriteLine("指定された内容: " + name);
                        }
                    }
                }
            }
        }

        static void DisplayHelp()
        {
            Console.WriteLine("このコマンドはテストです。");
            Console.WriteLine("");
            Console.WriteLine("ArgumentsTest [/s] [/k] [/y] [/name:[文字例]]");
            Console.WriteLine("");
            Console.WriteLine("    /s                あああという文字を表示します。");
            Console.WriteLine("    /k                任意のキーを押すように表示されます。");
            Console.WriteLine("    /name:[文字例]    指定された名前を表示します。");
            Console.WriteLine("    /?                このヘルプを表示します。");
            Console.WriteLine("");
            Console.WriteLine("このプログラムは適当に作りました。");
            Console.WriteLine("なんだこの自己満プログラム");
        }
    }
}
