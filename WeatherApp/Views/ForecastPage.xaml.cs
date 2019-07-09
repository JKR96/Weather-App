using WeatherApp.ViewModels;
using Xamarin.Forms;

namespace WeatherApp.Views
{
    public partial class ForecastPage : ContentPage
    {
        MainWeatherViewModel viewModel;

        public ForecastPage()
        {
            InitializeComponent();
            viewModel = new MainWeatherViewModel();
            viewModel.Title = "Prognoza pogody";
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadCommand.Execute(null);
        }

    }
}
