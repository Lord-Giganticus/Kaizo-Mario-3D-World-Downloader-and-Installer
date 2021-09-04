using System;
using System.Diagnostics;

namespace Updater.Classes
{
    public class Cmd
    {
        public static void Download(string url, string name)
        {
            var startinfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                WindowStyle = ProcessWindowStyle.Hidden,
                Arguments = $"/c Powershell Invoke-WebRequest -Uri \"{url}\" -OutFile \"{name}\"",
                CreateNoWindow = true,
                RedirectStandardOutput = true
            };
            Console.WriteLine("Downloding Update...");
            var p = Process.Start(startinfo);
            while (!p.HasExited)
            {
                if (p.HasExited)
                {
                    Console.WriteLine("Complete.");
                    break;
                }
            }
        }
    }
}
