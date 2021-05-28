using System;
using System.IO;
using Newtonsoft.Json;
using System.ComponentModel;


namespace Updater.Classes
{
    public abstract class SettingsBase
    {
        public abstract void Save();
    }

    public class TimeSettings : SettingsBase
    {
        public static DateTime Time { get => new DateTime(2021, 5, 28); }

        [DefaultValue(true)]
        public bool IsFirstRun { get; set; }

        public override void Save()
        {
            var data = JsonConvert.SerializeObject(this,Formatting.Indented);
            File.WriteAllText("Updater.json", data);
        }

        public static void Upgrade(ref TimeSettings settings) =>
            settings = JsonConvert.DeserializeObject<TimeSettings>(string.Join("", Webistes.WebsiteToString("https://lord-giganticus.github.io/Kaizo-Mario-3D-World-Downloader-and-Installer/Updater.json")));
    }
}
