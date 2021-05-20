using System;
using System.Diagnostics;
using System.IO;
using SM3DW_Keys;
using static Installer.Classes.Manager;

namespace Installer
{
    class Install
    {
        static void Main()
        {
            
            if (!File.Exists("URL.js"))
            {
                ExtractRecourse.ViaString("URL.js", Properties.Resources.URL);
            } if (!File.Exists("Run.cmd"))
            {
                ExtractRecourse.ViaString("Run.cmd", Properties.Resources.Run);
            }
            Console.WriteLine("Downloading files");
            Environment.CurrentDirectory = Directory.GetCurrentDirectory();
            Process.Start("CMD.exe", "/c Run.cmd && exit").WaitForExit();
            Console.WriteLine("Extracting zips");
            Process.Start("CMD.exe", "/c 7z x *.zip -xr!Extras && exit").WaitForExit();
            string[] normal_lines = { "[Definition]", "titleIds = "+EUR.key+","+USA.key+","+JPN.key, "name = Kaizo Mario 3D World Normal Mode", "path = \"Super Mario 3D World/Mods/Kaizo Mario 3D World/Normal Mode\"", "description = Mario's back and this time, I don't think he's gonna have it so easy...", "version = 5" };
            File.WriteAllLines("rules.txt", normal_lines);
            Process.Start("CMD.exe", "/c move rules.txt \"Kaizo Mario 3D World\" && exit").WaitForExit();
            string[] practice_lines = { "[Definition]", "titleIds = " + EUR.key + "," + USA.key + "," + JPN.key, "name = Kaizo Mario 3D World Practice Mode", "path = \"Super Mario 3D World/Mods/Kaizo Mario 3D World/Practice Mode\"", "description = Mario's back and this time, I don't think he's gonna have it so easy...", "version = 5" };
            File.WriteAllLines("rules.txt", practice_lines);
            Process.Start("CMD.exe", "/c move rules.txt \"Kaizo Mario 3D World Practice Mode\" && exit").WaitForExit();
            Console.WriteLine("Running nsis.cmd");
            Process.Start("CMD.exe", "/c nsis.cmd").WaitForExit();
            Console.WriteLine("Complete.");
            Environment.Exit(0);
        }  
    }
}
