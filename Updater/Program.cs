using System.IO;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            result = JArray.Parse(result)[0]["assets_url"].ToString();
            request = (HttpWebRequest)WebRequest.Create(result);
            request.UserAgent = "KM3DW-Updater";
            using (var r = (await request.GetResponseAsync()).GetResponseStream())
            {
                using var sr = new StreamReader(r);
                result = sr.ReadToEnd();
            }
            var name = JArray.Parse(result)[0]["name"].ToString();
            result = JArray.Parse(result)[0]["browser_download_url"].ToString();
            Cmd.Download(result, name);
            Console.ReadKey();
        }
    }
}
