using AccountingAppV3.Data;
using AccountingAppV3.Models;
using System.ComponentModel;

namespace AccountingAppV3.ViewModels
{

    public class MainPageViewModel : INotifyPropertyChanged
    {
        private Weather _weatherData;
        public Weather WeatherData
        {
            get => _weatherData;
            set
            {
                _weatherData = value;
                OnPropertyChanged(nameof(WeatherData));
            }
        }        
        public MainPageViewModel()
        {
            LoadWeatherData();
        }
        private async void LoadWeatherData()
        {
            string uri = "v1/weather?lat=58.673222&lon=17.074500";
            WeatherData = await WeatherDataManager.GetWeatherAsync(uri);
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyChanged)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyChanged));
        }
    }
}


