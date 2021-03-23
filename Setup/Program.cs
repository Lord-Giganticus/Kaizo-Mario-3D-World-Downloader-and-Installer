using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Setup
{
    class Program
    {
        static void Main(string[] args)
        {
            Classes.Arg arg = new Classes.Arg();
            var cmds = arg.Parse(args);
            string tag;
            if (!string.IsNullOrEmpty(cmds.ElementAt(0)))
            {
                var tag_check = double.Parse(cmds.ElementAt(0));
                if (tag_check > Properties.Settings.Default.tag)
                {
                    Properties.Settings.Default.tag = tag_check;
                    Properties.Settings.Default.Save();
                }
            }
            tag = Properties.Settings.Default.tag.ToString();
            Classes.Manager.ExtractResource extract = new Classes.Manager.ExtractResource();
            extract.String("UpdatesModule.js",Properties.Resources.UpdatesModule);
            extract.Bytes("curl.exe", Properties.Resources.curl);
            using (Process process = new Process())
            {
                ProcessStartInfo processStart = new ProcessStartInfo {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = "/c curl -k -L https://gamebanana.com/maps/211946?api=UpdatesModule -o update.json && node UpdatesModule.js"
                };
                process.StartInfo = processStart;
                process.Start();
                process.WaitForExit();
            }
            // Checks to see in the input tag is correct
            if (double.Parse(tag) > double.Parse(File.ReadAllText("tag.txt")) || double.Parse(tag) < double.Parse(File.ReadAllText("tag.txt")))
            {
                Properties.Settings.Default.tag = double.Parse(File.ReadAllText("tag.txt"));
                Properties.Settings.Default.Save();
                tag = File.ReadAllText("tag.txt");
            }
        }
    }

}
