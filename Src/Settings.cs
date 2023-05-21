using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Memorer.Src
{
    internal class Settings
    {
        public string? SuccessSoundFileName { get; set; }
        public string? NotificationSoundFileName { get; set; }

        [JsonIgnore]
        private IOLogic iOLogic = new();

        public float Volume { get; set; }

        public Settings()
        {
        }

        public void SaveSettingsToFile()
        {
            iOLogic.PutStringsToFile(this, IOLogic.Files.Settings);
        }
    }
}
