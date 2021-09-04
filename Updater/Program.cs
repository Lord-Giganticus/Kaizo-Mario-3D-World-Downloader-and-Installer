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
            Console.Title = $"Kaizo Mario 3D World Updater: Last built on {Data.CompileTime}";
            Console.ForegroundColor = ConsoleColor.Green;

            double Tag = 2.69;
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
            Time time = new(client);
            foreach (var r in await client.Repository.Release.GetAll("Lord-Giganticus", "Kaizo-Mario-3D-World-Downloader-and-Installer"))
            {
                releases.Add(r);
            }
            if (Tag != double.Parse(releases[0].TagName))
                if (!time.CheckTime(Data.CompileTimeOffest).GetAwaiter().GetResult())
                    Cmd.Download(releases[0].Assets[0].BrowserDownloadUrl, releases[0].Assets[0].Name);
                else
                    Console.WriteLine("No need to update. Press any key to exit.");
            else
                Console.WriteLine("No need to update. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
