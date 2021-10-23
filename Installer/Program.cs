using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;
using SM3DW_Keys;
using static Installer.Classes.Manager;

namespace Installer
{
    class Install
    {
        static void Main()
        {
            Console.WriteLine("Downloading files");
            Environment.CurrentDirectory = Directory.GetCurrentDirectory();
            using (var wc = new WebClient())
            {
                string result;
                result = wc.DownloadString("https://api.gamebanana.com/Core/Item/Data?itemtype=Mod&itemid=149492&fields=Files%28%29.aFiles%28%29");
                var arr = JArray.Parse(result);
                JToken[] objs = new JToken[((JObject)arr[0]).Count];
                objs = arr[0].ToArray();
                (string name, string url)[] downloads = new (string name, string url)[objs.Length];
                for (int i = 0; i < objs.Length; i++)
                {
                    downloads[i] = (objs[i].First.First.Next.ToObject<string>(), objs[i].First.Last.ToObject<string>());
                }
                foreach (var (name, url) in downloads)
                {
                    var request = (HttpWebRequest)WebRequest.Create(url);
                    using (var r = request.GetResponse().GetResponseStream())
                    {
                        using (var f = new FileStream(name, FileMode.Create, FileAccess.Write))
                        {
                            r.CopyTo(f);
                        }
                    }
                }
            }  
            Console.WriteLine("Extracting zips");
            Process.Start("CMD.exe", "/c 7z x *.zip -xr!Extras && exit").WaitForExit();
            File.Delete("Kaizo Mario 3D World/meta/meta.xml");
            File.Delete("Kaizo Mario 3D World Practice Mode/meta/meta.xml");
            string[] normal_lines = { "[Definition]", "titleIds = "+EUR.key+","+USA.key+","+JPN.key, "name = Kaizo Mario 3D World Normal Mode", "path = \"Super Mario 3D World/Mods/Kaizo Mario 3D World/Normal Mode\"", "description = Mario's back and this time, I don't think he's gonna have it so easy...", "version = 5" };
            File.WriteAllLines("rules.txt", normal_lines);
            File.Move("rules.txt", "Kaizo Mario 3D World/rules.txt");
            string[] practice_lines = { "[Definition]", "titleIds = " + EUR.key + "," + USA.key + "," + JPN.key, "name = Kaizo Mario 3D World Practice Mode", "path = \"Super Mario 3D World/Mods/Kaizo Mario 3D World/Practice Mode\"", "description = Mario's back and this time, I don't think he's gonna have it so easy...", "version = 5" };
            File.WriteAllLines("rules.txt", practice_lines);
            File.Move("rules.txt", "Kaizo Mario 3D World Practice Mode/rules.txt");
            Console.WriteLine("Running nsis.cmd");
            Process.Start("CMD.exe", "/c nsis.cmd").WaitForExit();
            Console.WriteLine("Complete.");
            Environment.Exit(0);
        }  
    }
}
