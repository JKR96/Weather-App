using System;
using System.Collections.Generic;
using WeatherApp.ViewModels;
using Xamarin.Forms;

namespace WeatherApp.Views
{
    public partial class MainWeatherPage : ContentPage
    {
        MainWeatherViewModel viewModel;

        public MainWeatherPage()
        {
            InitializeComponent();
            viewModel = new MainWeatherViewModel();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadCommand.Execute(null);
        }
    }

}
