using System;
using System.Diagnostics;
using System.Threading.Tasks;
using PropertyChanged;
using WeatherApp.Models;
using WeatherApp.Models.DTOs;
using WeatherApp.Models.Helpers;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainWeatherViewModel : BaseViewModel
    {
        public ForecastWeatherDTO Weather { get; set; }
        public string BackgroundImage { get; set; }
        public Command LoadCommand { get; set; }

        public MainWeatherViewModel()
        {
            Title = "Weather";
            LoadCommand = new Command(async () => await ExecuteLoadCommand());
        }

        async Task ExecuteLoadCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                // Get weather
                Xamarin.Essentials.Location location = await Geolocation.GetLastKnownLocationAsync();
                if (location == null)
                {
                    location = new Xamarin.Essentials.Location(50.0, 22.0);
                }
                Weather = await GetForecastWeather(location, Configuration.API_LANGAUGE);
                
                // Get weather descriptions to download images
                CurrentWeatherDTO descriptionWeather = await GetWeather(location, "en");

                // Set day or night
                string condition = descriptionWeather.Current.Condition.Text;
                string strSunrise = Weather.Forecast.Forecastday[0].Astro.Sunrise;
                string strSunset = Weather.Forecast.Forecastday[0].Astro.Sunset;
                DateTime sunrise = DateTime.Parse(strSunrise);
                DateTime sunset = DateTime.Parse(strSunset);

                BackgroundImage = "https://images.unsplash.com/photo-1525490829609-d166ddb58678?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=2698&q=80";

                if (DateTime.Now.Hour > sunrise.Hour && DateTime.Now.Hour < sunset.Hour)
                {
                    //Day

                    if (condition.Contains("sunny"))
                    {
                        BackgroundImage = "https://images.unsplash.com/photo-1525490829609-d166ddb58678?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=2698&q=80";
                    }
                    else if (condition.Contains("partly sunny"))
                    {
                        BackgroundImage = "https://images.unsplash.com/photo-1525490829609-d166ddb58678?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=2698&q=80";
                    }
                    else if (condition.Contains("cloud") ||
                        condition.Contains("overcast"))
                    {

                    }
                    else if (condition.Contains("mist") ||
                        condition.Contains("fog"))
                    {

                    }
                    else if (condition.Contains("rain") ||
                        condition.Contains("drizzle"))
                    {

                    }
                    else if (condition.Contains("snow") ||
                        condition.Contains("sleet") ||
                        condition.Contains("blizzard") ||
                        condition.Contains("ice"))
                    {

                    }
                    else if (condition.Contains("thunder") ||
                        condition.Contains("overcast"))
                    {

                    }
                }
                else // Night
                {
                    if (condition.Contains("sunny"))
                    {

                    }
                    else if (condition.Contains("partly sunny"))
                    {

                    }
                    else if (condition.Contains("cloud") ||
                        condition.Contains("overcast"))
                    {

                    }
                    else if (condition.Contains("mist") ||
                        condition.Contains("fog"))
                    {

                    }
                    else if (condition.Contains("rain") ||
                        condition.Contains("drizzle"))
                    {

                    }
                    else if (condition.Contains("snow") ||
                        condition.Contains("sleet") ||
                        condition.Contains("blizzard") ||
                        condition.Contains("ice"))
                    {

                    }
                    else if (condition.Contains("thunder") ||
                        condition.Contains("overcast"))
                    {

                    }
                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private static async Task<CurrentWeatherDTO> GetWeather(Xamarin.Essentials.Location location,
            string lang)
        {
            return await APIHelpers.Get<CurrentWeatherDTO>(
                Configuration.API_URL +
                "current.json?key=" +
                Configuration.API_KEY +
                "&q=" +
                location.Latitude + "," + location.Longitude +
                "&lang=" + lang);
        }

        private static async Task<ForecastWeatherDTO> GetForecastWeather(Xamarin.Essentials.Location location,
            string lang)
        {
            return await APIHelpers.Get<ForecastWeatherDTO>(
                Configuration.API_URL +
                "forecast.json?key=" +
                Configuration.API_KEY +
                "&q=" +
                location.Latitude + "," + location.Longitude +
                "&lang=" + lang);
        }

    }
}
