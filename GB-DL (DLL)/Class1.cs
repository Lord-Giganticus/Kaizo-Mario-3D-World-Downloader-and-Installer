using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace GB_DL
{
    public class API
    {
        public static void Main(string args)
        {
            Environment.CurrentDirectory = Directory.GetCurrentDirectory();
            if (args.StartsWith("https://gamebanana.com") == false)
            {
                Console.WriteLine("I need a Gamebanana url in order to work!");
                Environment.Exit(1);
            }
            else
            {
                if (args.EndsWith("?api=FilesModule") == false)
                {
                    if (args.EndsWith("?api=FilesModule") == false)
                    {
                        Console.WriteLine("I need the following to be added to the url at the end:\t?api=FilesModule");
                        Environment.Exit(1);
                    }
                }
                else
                {
                    string url = args;
                    using (var client = new WebClient())
                    {
                        client.DownloadFile(url, "config.json");
                    }
                }
                Process.Start("CMD.exe", "/c node app > download.cmd && download.cmd && del /f download.cmd && exit").WaitForExit();
                Console.WriteLine("Complete.");
                return;
            }
        }
    }
}
