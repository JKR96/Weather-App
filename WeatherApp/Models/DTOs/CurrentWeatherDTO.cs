using System;
using Newtonsoft.Json;

namespace WeatherApp.Models.DTOs
{
    public class CurrentWeatherDTO
    {
        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("current")]
        public Current Current { get; set; }
    }
}
