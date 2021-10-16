﻿using System;
using System.Diagnostics;
using System.IO;
using System.Net;
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
            var request = (HttpWebRequest)WebRequest.Create("https://gamebanana.com/dl/543972");
            using (var f = File.Create("kaizo_mario_3d_world_269.zip"))
            {
                using (var stream = request.GetResponse().GetResponseStream())
                {
                    stream.CopyTo(f);
                }
            }
            request = (HttpWebRequest)WebRequest.Create("https://gamebanana.com/dl/543971");
            using (var f = File.Create("kaizo_mario_3d_world_practice_269.zip"))
            {
                using (var stream = request.GetResponse().GetResponseStream())
                {
                    stream.CopyTo(f);
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
