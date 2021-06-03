using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;

namespace Updater.Classes
{
    public class Time
    {
        private protected GitHubClient Client { get; set; }

        public Time(GitHubClient _Client)
        {
            Client = _Client;
        }

        public async Task<bool> CheckTime(DateTimeOffset Time)
        {
            var releases = await Client.Repository.Release.GetAll("Lord-Giganticus", "Kaizo-Mario-3D-World-Downloader-and-Installer");
            var release = releases[0];
            if (release.CreatedAt > Time)
                return false;
            else
                return true;
        }
    }
}
