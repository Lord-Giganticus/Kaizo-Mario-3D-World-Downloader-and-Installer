using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace Updater
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile("https://api.github.com/repos/Lord-Giganticus/Kaizo-Mario-3D-World-Downloader-and-Installer/releases/latest", "config.json");
            }
            Process.Start("CMD.exe", "node checker 2.04 > download.cmd");
            foreach (string line in File.ReadLines("download.cmd"))
            {
                if (line.Contains("https://github.com/Lord-Giganticus/Kaizo-Mario-3D-World-Downloader-and-Installer")) {
                    goto need_update;
                }
            }
            goto no_update;
        need_update:
            Process.Start("CMD.exe","/c download.cmd && exit").WaitForExit();
            Environment.Exit(0);
        no_update:
            Console.WriteLine("No need to update! Exiting.");
            Environment.Exit(0);
        }
    }
}
