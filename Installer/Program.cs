﻿using System;
using System.IO;
using System.Diagnostics;
using System.Net;
using Gamebanana_Downloader;

namespace Installer
{
    class Install
    {
        static void Main()
        {
            API.Main("https://gamebanana.com/maps/211946");
        }
    }
}
