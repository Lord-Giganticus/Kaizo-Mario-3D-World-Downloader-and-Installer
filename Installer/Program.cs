using GB_DL;
using System;
using System.Diagnostics;
using System.IO;
using SM3DW_Keys;

namespace Installer
{
    class Install
    {
        static void Main()
        {
            API.Main("https://gamebanana.com/maps/211946?api=FilesModule");
            Environment.CurrentDirectory = Directory.GetCurrentDirectory();
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
            Process.Start("CMD.exe", "/c nsis.cmd && zip.cmd && move.cmd && exit").WaitForExit();
            Environment.Exit(0);
        }  
    }
}
