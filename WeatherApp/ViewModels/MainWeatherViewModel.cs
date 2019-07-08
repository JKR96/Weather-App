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
        public CurrentWeatherDTO Weather { get; set; }
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
                var location = await Geolocation.GetLastKnownLocationAsync();

                var weather = await APIHelpers.Get<CurrentWeatherDTO>(
                    Configuration.API_URL +
                    "current.json?key=" +
                    Configuration.API_KEY +
                    "&q=" +
                    location.Latitude + "," + location.Longitude);
                Weather = weather;
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

    }
}
