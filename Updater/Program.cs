﻿using System;
using Newtonsoft.Json.Linq;
using System.IO;
using Updater.Classes;
using System.Collections.Generic;

namespace Updater
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeSettings settings;

            if (!File.Exists("Updater.json")) {
                settings = new TimeSettings
                {
                    IsFirstRun = false
                };
                settings.Save();
            } else
            {
                settings = new TimeSettings();
                TimeSettings.Upgrade(ref settings);
                settings.Save();
            }

            var sites = Webistes.WebsiteToString($"https://api.github.com/repos/Lord-Giganticus/Kaizo-Mario-3D-World-Downloader-and-Installer/tags");
            var site = string.Join("", sites);
            var a = JArray.Parse(site);
            var l = new List<Datas>();
            foreach (JObject o in a.Children<JObject>())
                foreach (var p in o.Properties())
                    l.Add(new Datas
                    {
                        Name = p.Value.ToString()
                    });
            var data = l[5];    
            try
            {
                var arg_tag = double.Parse(args[0]);
                var date = DateTime.Parse(args[1]);
                var tag = double.Parse(data.Name);
                if (arg_tag != tag || TimeSettings.Time != date)
                    Curl.DownloadUpdate(tag);
                else
                    Console.WriteLine("No need to update!");
            } catch 
            {
                Console.WriteLine("Enter the tag the installer was from:");
                var arg_tag = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter the day the installer was from in the format Year/Month/Day:");
                var date = DateTime.Parse(Console.ReadLine());
                var tag = double.Parse(data.Name);
                if (arg_tag != tag || TimeSettings.Time != date)
                    Curl.DownloadUpdate(tag);
                else
                    Console.WriteLine("No need to update!");
            }
        }
    }
}
