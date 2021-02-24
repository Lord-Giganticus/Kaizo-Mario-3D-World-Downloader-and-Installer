using System;
using System.IO;
using System.Diagnostics;
using System.Net;

namespace Gamebanana_Downloader
{
    class Program
    {
        static void Main(string[] args)
        {
            Environment.CurrentDirectory = Directory.GetCurrentDirectory();
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter a argument.");
                Environment.Exit(1);
            }
            if (args[0].StartsWith("https://gamebanana.com") == false)
            {
                Console.WriteLine("I need a Gamebanana url in order to work!");
                Environment.Exit(1);
            } else
            {
                if (args[0].EndsWith("?api=FilesModule") == false)
                {
                    string url = args[0]+"?api=FilesModule";
                    using (var client = new WebClient())
                    {
                        client.DownloadFile(url, "config.json");
                    }
                } else
                {
                    string url = args[0];
                    using (var client = new WebClient())
                    {
                        client.DownloadFile(url, "config.json");
                    }
                }
                Process.Start("CMD.exe","/c node app > download.cmd && download.cmd && del /f download.cmd && exit").WaitForExit();
                Console.WriteLine("Complete.");
                Environment.Exit(0);
            }
        }
    }
}
