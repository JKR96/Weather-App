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
                string condition = descriptionWeather.Current.Condition.Text;
                SetBackgroundImage(condition);

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

        private void SetBackgroundImage(string condition)
        {
            if (Weather.Current.IsDay == 1)
            {
                //Day

                if (condition.ToLower().Contains("sunny"))
                {
                    BackgroundImage = "https://images.unsplash.com/photo-1525490829609-d166ddb58678?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=2698&q=80";
                }
                else if (condition.ToLower().Contains("partly sunny"))
                {
                    BackgroundImage = "https://images.unsplash.com/photo-1525490829609-d166ddb58678?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=2698&q=80";
                }
                else if (condition.ToLower().Contains("cloud") ||
                    condition.ToLower().Contains("overcast"))
                {
                    BackgroundImage = "https://images.unsplash.com/photo-1534088568595-a066f410bcda?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=989&q=80";
                }
                else if (condition.ToLower().Contains("mist") ||
                    condition.ToLower().Contains("fog"))
                {
                    BackgroundImage = "https://images.unsplash.com/photo-1455656678494-4d1b5f3e7ad4?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1950&q=80";
                }
                else if (condition.ToLower().Contains("rain") ||
                    condition.ToLower().Contains("drizzle"))
                {
                    BackgroundImage = "https://images.unsplash.com/photo-1525087740718-9e0f2c58c7ef?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=2734&q=80";
                }
                else if (condition.ToLower().Contains("snow") ||
                    condition.ToLower().Contains("sleet") ||
                    condition.ToLower().Contains("blizzard") ||
                    condition.ToLower().Contains("ice"))
                {
                    BackgroundImage = "https://images.unsplash.com/photo-1543751737-d7cf492060cd?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1952&q=80";
                }
                else if (condition.ToLower().Contains("thunder") ||
                    condition.ToLower().Contains("overcast"))
                {
                    BackgroundImage = "https://images.pexels.com/photos/1051425/pexels-photo-1051425.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260";
                }
            }
            else // Night
            {
                if (condition.ToLower().Contains("clear"))
                {
                    BackgroundImage = "https://images.unsplash.com/photo-1532798369041-b33eb576ef16?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1001&q=80";
                }
                else if (condition.ToLower().Contains("cloud") ||
                    condition.ToLower().Contains("overcast"))
                {
                    BackgroundImage = "https://images.unsplash.com/photo-1518128160709-c575457dafa5?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=934&q=80";
                }
                else if (condition.ToLower().Contains("mist") ||
                    condition.ToLower().Contains("fog"))
                {
                    BackgroundImage = "https://images.pexels.com/photos/327308/pexels-photo-327308.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260";
                }
                else if (condition.ToLower().Contains("rain") ||
                    condition.ToLower().Contains("drizzle"))
                {
                    BackgroundImage = "https://images.pexels.com/photos/396547/pexels-photo-396547.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260";
                }
                else if (condition.ToLower().Contains("snow") ||
                    condition.ToLower().Contains("sleet") ||
                    condition.ToLower().Contains("blizzard") ||
                    condition.ToLower().Contains("ice"))
                {
                    BackgroundImage = "https://images.pexels.com/photos/773594/pexels-photo-773594.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260";
                }
                else if (condition.ToLower().Contains("thunder") ||
                    condition.ToLower().Contains("overcast"))
                {
                    BackgroundImage = "https://images.pexels.com/photos/1162251/pexels-photo-1162251.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260";
                }
            }

            if (string.IsNullOrEmpty(BackgroundImage))
            {
                BackgroundImage = "https://images.unsplash.com/photo-1525490829609-d166ddb58678?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=2698&q=80";
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
                "&lang=" + lang +
                "&days=7");
        }

    }
}
