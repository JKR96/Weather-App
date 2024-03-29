﻿using WeatherApp.ViewModels;
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
            viewModel.Title = "Aktualna pogoda";
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadCommand.Execute(null);
        }
    }

}
