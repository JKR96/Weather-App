using System;
using Newtonsoft.Json;

namespace WeatherApp.Models.DTOs
{
    public class Condition
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("code")]
        public long Code { get; set; }
    }
}
