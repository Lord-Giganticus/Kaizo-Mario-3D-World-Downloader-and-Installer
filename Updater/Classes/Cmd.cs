using System;
using System.Net;
using System.IO;

namespace Updater.Classes
{
    public class Cmd
    {
        public static void Download(string url, string name)
        {
            Console.WriteLine("Downloding Update...");
            var request = (HttpWebRequest)WebRequest.Create(url);
            using var f = new FileStream(name, FileMode.OpenOrCreate);
            using var stream = request.GetResponse().GetResponseStream();
            stream.CopyTo(f);
            Console.WriteLine("Complete.");
        }
    }
}
