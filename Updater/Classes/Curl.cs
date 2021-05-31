using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Updater.Classes
{
    public class Curl
    {
        public static void Download(string url, string name)
        {
            var startinfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                WindowStyle = ProcessWindowStyle.Hidden,
                Arguments = $"/c curl -k -L {url} -o {name}",
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
