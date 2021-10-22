using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Net;
using Updater.Classes;

namespace Updater
{
    static class Program
    {
        static void Main() => MainAsync().GetAwaiter().GetResult();

        internal async static Task MainAsync()
        {
            var request = (HttpWebRequest)WebRequest.Create("https://api.github.com/repos/Lord-Giganticus/Kaizo-Mario-3D-World-Downloader-and-Installer/releases");
            request.UserAgent = "KM3DW-Updater";
            string result;
            using (var r = (await request.GetResponseAsync()).GetResponseStream())
            {
                using var sr = new StreamReader(r);
                result = sr.ReadToEnd();
            }
            var start = result.IndexOf("assets_url\":");
            start = result.IndexOf(':', start) + 2;
            var end = result.IndexOf(',', start) - 1;
            result = result[start..end];
            request = (HttpWebRequest)WebRequest.Create(result);
            request.UserAgent = "KM3DW-Updater";
            using (var r = (await request.GetResponseAsync()).GetResponseStream()) 
            {
                using var sr = new StreamReader(r);
                result = sr.ReadToEnd();
            }
            start = result.IndexOf("browser_download_url\":");
            start = result.IndexOf(':', start) + 2;
            end = result.IndexOf("\"", start);
            result = result[start..end];
            var name = result[(result.LastIndexOf('/')+ 1)..];
            Cmd.Download(result, name);
        }
    }
}
