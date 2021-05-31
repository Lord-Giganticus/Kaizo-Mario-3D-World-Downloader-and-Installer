using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Octokit;
using Updater.Classes;

namespace Updater
{
    class Program
    {
        static void Main(string[] args) => MainAsync(args.ToList()).GetAwaiter().GetResult();

        internal async static Task MainAsync(List<string> args)
        {
            double? Tag = null;
            foreach (var arg in args)
            {
                switch (arg)
                {
                    case "-t":
                    case "--tag":
                        Tag = double.Parse(args[args.IndexOf("-t") + 1]);
                        break;
                }
            }
            if (Tag == null)
            {
                Console.WriteLine("Enter the tag this Updater was from below.");
                Tag = double.Parse(Console.ReadLine());
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
                        Curl.Download(releases[0].Assets[0].BrowserDownloadUrl, releases[0].Assets[0].Name);
                        break;
                }
            }
        }
    }
}
