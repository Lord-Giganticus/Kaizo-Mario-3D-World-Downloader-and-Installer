using System.Collections.Generic;
using System.Diagnostics;

namespace Updater.Classes
{
    public class Webistes
    {
        public static string[] WebsiteToString(string URL)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = $"/c curl {URL}",
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            var process = Process.Start(startInfo);
            var lines = new List<string>();
            while (!process.HasExited)
                if (!process.HasExited)
                    lines.Add(process.StandardOutput.ReadLine());
                else
                    break;
            return lines.ToArray();
        }
    }
}
