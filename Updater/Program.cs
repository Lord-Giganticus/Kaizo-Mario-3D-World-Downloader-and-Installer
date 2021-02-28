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
        }
    }
}
