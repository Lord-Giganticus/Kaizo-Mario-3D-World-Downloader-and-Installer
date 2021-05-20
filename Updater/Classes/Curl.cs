using System;
using System.Diagnostics;

namespace Updater.Classes
{
    class Curl
    {
        public static void DownloadUpdate(double tag)
        {
            var info = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                WindowStyle = ProcessWindowStyle.Hidden,
                Arguments = $"/c curl -k -L https://github.com/Lord-Giganticus/Kaizo-Mario-3D-World-Downloader-and-Installer/releases/download/{tag}/Kaizo.Mario.3D.World.exe -o Kaizo.Mario.3D.World.exe",
                CreateNoWindow = true,
                RedirectStandardOutput = true
            };
            var p = Process.Start(info);
            Console.WriteLine("Downloading Update.");
            while (!p.HasExited)
                if (!p.HasExited)
                    Console.WriteLine(p.StandardOutput.ReadLine());
                else
                    break;
            Console.WriteLine("Update Downloaded.");
        }
    }
}
