using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JupiterToysPlanITTest.Configurations
{
   public class Settings
    {
        static readonly Settings Content;

        [JsonProperty("BaseURL")]
        public static string BaseURL { get; set; }

        [JsonProperty("Browser")]
        public static string Browser { get; set; }

        [JsonProperty("WaitingTime")]
        public static int WaitingTime { get; set; }

        static Settings() {
            var path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);
            Content = JsonConvert.DeserializeObject<Settings>(File.ReadAllText( path + "/Configurations/Settings.json"));
        }

    }
}
