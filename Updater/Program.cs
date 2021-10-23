using System.IO;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using Updater.Classes;
using System.Linq;

namespace Updater
{
    static class Program
    {
        static void Main() => MainAsync().GetAwaiter().GetResult();

        internal async static Task MainAsync()
        {
            Console.WriteLine("Do you want to download the installer or the latest zip file(s)?\n[1] Installer\n[2] Zip file(s)");
            var resp = Console.ReadKey(true);
            switch (resp.Key)
            {
                case ConsoleKey.D1:
                    await GetInstaller();
                    break;
                case ConsoleKey.D2:
                    await GetZips();
                    break;
                default:
                    Console.WriteLine("Defaulting to getting the installer.");
                    await GetInstaller();
                    break;
            }
            Console.WriteLine("Complete. Press any key to exit.");
            Console.ReadKey(true);
        }

        internal async static Task GetInstaller()
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

        internal async static Task GetZips()
        {
            Console.WriteLine("Which zip would you like to download?\n[1] Normal\n[2] Pratice\n[3] Both");
            var res = Console.ReadKey(true);
            string result;
            using var wc = new WebClient();
            result = await wc.DownloadStringTaskAsync("https://api.gamebanana.com/Core/Item/Data?itemtype=Mod&itemid=149492&fields=Files%28%29.aFiles%28%29");
            var arr = JArray.Parse(result);
            JToken[] objs = new JToken[((JObject)arr[0]).Count];
            objs = arr[0].ToArray();
            (string name, string url)[] downloads = new (string name, string url)[objs.Length];
            for (int i = 0; i < objs.Length; i++)
            {
                downloads[i] = (objs[i].First.First.Next.ToObject<string>(), objs[i].First.Last.ToObject<string>());
            }
            switch (res.Key)
            {
                case ConsoleKey.D1:
                    Cmd.Download(downloads[0].url, downloads[0].name);
                    break;
                case ConsoleKey.D2:
                    Cmd.Download(downloads[1].url, downloads[1].name);
                    break;
                case ConsoleKey.D3:
                    for (int i = 0; i < 2; i++)
                    {
                        Cmd.Download(downloads[i].url, downloads[i].name);
                    }
                    break;
                default:
                    Console.WriteLine("Defaulting to getting both.");
                    for (int i = 0; i < 2; i++)
                    {
                        Cmd.Download(downloads[i].url, downloads[i].name);
                    }
                    break;
            }
        }
    }
}
