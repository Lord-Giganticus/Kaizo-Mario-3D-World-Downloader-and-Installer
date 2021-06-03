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
            Console.Title = "Kaizo Mario 3D World Updater";
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Blue;

            double? Tag = null;
            foreach (var arg in args)
            {
                Tag = arg switch
                {
                    "-t" or "--tag" => double.Parse(args[args.IndexOf("-t") + 1] ?? args[args.IndexOf("--tag") + 1]),
                    _ => 2.69
                };
            }
            var releases = new List<Release>();
            var client = new GitHubClient(new ProductHeaderValue("KM3DW-Updater"));
            Time time = new Time(client);
            foreach (var r in await client.Repository.Release.GetAll("Lord-Giganticus", "Kaizo-Mario-3D-World-Downloader-and-Installer"))
            {
                releases.Add(r);
            }
            if (Tag != double.Parse(releases[0].TagName))
            {
                if (!time.CheckTime(Data.CompileTimeOffest).GetAwaiter().GetResult())
                    Curl.Download(releases[0].Assets[0].BrowserDownloadUrl, releases[0].Assets[0].Name);
            }
            else if (!time.CheckTime(Data.CompileTimeOffest).GetAwaiter().GetResult())
                Curl.Download(releases[0].Assets[0].BrowserDownloadUrl, releases[0].Assets[0].Name);
        }
    }
}
