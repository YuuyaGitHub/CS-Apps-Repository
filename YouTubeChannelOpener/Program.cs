using System;

namespace YouTubeChannelOpener
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                string input = args[0];
                if (input.StartsWith("/id:"))
                {
                    string channelId = input.Substring(4);

                    string youtubeUrl = "https://www.youtube.com/channel/" + channelId;

                    System.Diagnostics.Process.Start(youtubeUrl);
                }
                else
                {
                    Help();
                }
            }
            else
            {
                Help();
            }
        }
        static void Help()
        {
            Console.WriteLine("指定したYouTubeのチャンネルを開きます。");
            Console.WriteLine("");
            Console.WriteLine("YouTubeChannelOpener.exe [/id:チャンネルID]");
            Console.WriteLine("");
            Console.WriteLine("    [/id:チャンネルID]    開くチャンネルIDを指定します。");
            Console.WriteLine("");
            Console.WriteLine("このプログラムでは、YouTubeのチャンネルID形式のみ対応しています。");
            Console.WriteLine("YouTubeハンドル名やカスタムURLには対応していません。");
            Console.WriteLine("");
            Console.WriteLine("YouTubeのチャンネルIDを取得するには、次の手順を実行します。");
            Console.WriteLine("");
            Console.WriteLine("1. 取得したいチャンネルのページを開きます。");
            Console.WriteLine("2. 右側の「共有」をクリックします。");
            Console.WriteLine("3. 「チャンネル ID をコピー」を選択します。");
            Console.WriteLine("");
            Console.WriteLine("次の例は、Yuuyaチャンネルを開きます:");
            Console.WriteLine("YouTubeChannelOpener.exe /id:UCKMQY0OXZhdiRnbGN9Nm5kA");


        }
    }
}
