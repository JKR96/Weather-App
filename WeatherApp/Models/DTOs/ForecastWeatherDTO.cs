using System;
using Newtonsoft.Json;

namespace WeatherApp.Models.DTOs
{
    public class ForecastWeatherDTO
    {
        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("current")]
        public Current Current { get; set; }

        [JsonProperty("forecast")]
        public Forecast Forecast { get; set; }
    }
}
