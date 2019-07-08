using System;
using Newtonsoft.Json;

namespace WeatherApp.Models.DTOs
{
    public class Forecast
    {
        [JsonProperty("forecastday")]
        public Forecastday[] Forecastday { get; set; }
    }
}
