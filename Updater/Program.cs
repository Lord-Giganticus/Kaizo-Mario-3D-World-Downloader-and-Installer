using System;
using System.Diagnostics;
using System.IO;

namespace Updater
{
    class Program
    {
        static void Main(string[] args)
        {
            Process.Start("CMD.exe", "/c curl https://api.github.com/repos/Lord-Giganticus/Kaizo-Mario-3D-World-Downloader-and-Installer/releases/latest -o config.json");
            Process.Start("CMD.exe", "/c node checker 2.04 > download.cmd");
            foreach (string line in File.ReadLines("download.cmd"))
            {
                if (line.Contains("curl") == true) {
                    goto need_update;
                }
            }
            goto no_update;
        need_update:
            Process.Start("CMD.exe","/c download.cmd").WaitForExit();
            Environment.Exit(0);
        no_update:
            Console.WriteLine("No need to update! Exiting.");
            Environment.Exit(0);
        }
    }
}
