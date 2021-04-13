using System;
using System.Diagnostics;
using System.IO;
using SM3DW_Keys;
using System.Net;

namespace Installer
{
    class Install
    {
        static void Main()
        {
            Classes.Manager.ExtractRecourse extract = new Classes.Manager.ExtractRecourse();
            if (!File.Exists("curl.exe"))
            {
                extract.ViaBytes("curl.exe",Properties.Resources.curl);
            } if (!File.Exists("URL.js"))
            {
                extract.ViaString("URL.js", Properties.Resources.URL);
            } if (!File.Exists("7z.exe"))
            {
                extract.ViaBytes("7z.exe", Properties.Resources._7z);
            }
            Console.WriteLine("Downloading files");
            Environment.CurrentDirectory = Directory.GetCurrentDirectory();
            Process.Start("CMD.exe", "/c curl -k -L https://gamebanana.com/maps/download/211946?api=FilesModule -o config.json").WaitForExit();
            Process.Start("CMD.exe", "/c node URL.js > download.cmd && download.cmd && del /f download.cmd && exit").WaitForExit();
            Console.WriteLine("Extracting zips");
            Process.Start("CMD.exe", "/c 7z x *.zip -x!\"KM3D Banner.png\" -x!\"KM3D Icon.png\" -x!\"KM3D Logo.png\" -x!\"KM3Dpm Banner.png\" -x!\"KM3Dpm Icon.png\" -x!\"KM3Dpm Logo.png\" -x!\"Update 2.0.png\" && exit").WaitForExit();
            string[] normal_lines = { "[Definition]", "titleIds = "+EUR.key+","+USA.key+","+JPN.key, "name = Kaizo Mario 3D World Normal Mode", "path = \"Super Mario 3D World/Mods/Kaizo Mario 3D World/Normal Mode\"", "description = Mario's back and this time, I don't think he's gonna have it so easy...", "version = 5" };
            using (StreamWriter outputFile = new StreamWriter("rules.txt"))
            {
                foreach (string line in normal_lines)
                    outputFile.WriteLine(line);
            }
            Process.Start("CMD.exe", "/c move rules.txt \"Kaizo Mario 3D World\" && exit").WaitForExit();
            string[] practice_lines = { "[Definition]", "titleIds = " + EUR.key + "," + USA.key + "," + JPN.key, "name = Kaizo Mario 3D World Practice Mode", "path = \"Super Mario 3D World/Mods/Kaizo Mario 3D World/Practice Mode\"", "description = Mario's back and this time, I don't think he's gonna have it so easy...", "version = 5" };
            using (StreamWriter outputFile = new StreamWriter("rules.txt"))
            {
                foreach (string line in practice_lines)
                    outputFile.WriteLine(line);
            }
            Process.Start("CMD.exe", "/c move rules.txt \"Kaizo Mario 3D World Practice Mode\" && exit").WaitForExit();
            Console.WriteLine("Running nsis.cmd");
            Process.Start("CMD.exe", "/c nsis.cmd").WaitForExit();
            Console.WriteLine("Complete.");
            Environment.Exit(0);
        }  
    }
}
