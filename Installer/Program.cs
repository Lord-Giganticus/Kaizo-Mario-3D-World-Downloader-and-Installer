using GB_DL;
using System;
using System.Diagnostics;
using System.IO;

namespace Installer
{
    class Install
    {
        static void Main()
        {
            API.Main("https://gamebanana.com/maps/211946?api=FilesModule");
            Environment.CurrentDirectory = Directory.GetCurrentDirectory();
            Process.Start("CMD.exe", "/c 7z x *.zip -x!\"KM3D Banner.png\" -x!\"KM3D Icon.png\" -x!\"KM3D Logo.png\" -x!\"KM3Dpm Banner.png\" -x!\"KM3Dpm Icon.png\" -x!\"KM3Dpm Logo.png\" -x!\"Update 2.0.png\" && exit").WaitForExit();
        }
    }
}
