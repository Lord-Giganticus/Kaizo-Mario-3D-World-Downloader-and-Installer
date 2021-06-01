using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Octokit;
using Updater.Classes;

namespace Updater
{
    class Program
    {
        private protected static DateTimeOffset dateTime = new DateTimeOffset(new DateTime(2021, 5, 31, 9, 0, 0));

        static void Main(string[] args) => MainAsync(args.ToList()).GetAwaiter().GetResult();

        internal async static Task MainAsync(List<string> args)
        {
            double? Tag = null;
            foreach (var arg in args)
            {
                Tag = arg switch
                {
                    "-t" or "--tag" => double.Parse(args[args.IndexOf("-t") + 1]),
                    _ => 2.69,
                };
            }
            var releases = new List<Release>();
            var client = new GitHubClient(new ProductHeaderValue("KM3DW-Updater"));
            foreach (var r in await client.Repository.Release.GetAll("Lord-Giganticus", "Kaizo-Mario-3D-World-Downloader-and-Installer"))
            {
                releases.Add(r);
            }
            if (Tag != double.Parse(releases[0].TagName))
            {
                Curl.Download(releases[0].Assets[0].BrowserDownloadUrl, releases[0].Assets[0].Name);
            } else
            {
                Console.WriteLine("You sure this is the latest version? Yes/No");
                switch (Console.ReadLine())
                {
                    case "no":
                    case "NO":
                    case "nO":
                    case "No":
                        var t = new Time(client);
                        if (!t.CheckTime(dateTime).GetAwaiter().GetResult())
                            Curl.Download(releases[0].Assets[0].BrowserDownloadUrl, releases[0].Assets[0].Name);
                        else
                            Console.WriteLine("Time check suggests that there is no need to update!");
                        break;
                }
            }
        }
    }
}
