using AccountingAppV3.Data;
using AccountingAppV3.Models;
using System.ComponentModel;

namespace AccountingAppV3.ViewModels
{

    public class MainPageViewModel : INotifyPropertyChanged
    {
        public string WindDescription { get; set; }
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
        private void SetWindDesciption(float windSpeed)
        {
            if (windSpeed <= 0.2)
            {
                WindDescription = "Lugnt";
            }
            else if (windSpeed > 0.2 && windSpeed <= 3.3)
            {
                WindDescription = "Svag vind";
            }
            else if (windSpeed > 3.3 && windSpeed <= 7.9)
            {
                WindDescription = "Måttlig vind";
            }
            else if (windSpeed > 7.9 && windSpeed <= 13.8)
            {
                WindDescription = "Frisk vind";
            }
            else if (windSpeed > 13.8 && windSpeed <= 24.4)
            {
                WindDescription = "Hård vind";
            }
            else if (windSpeed > 24.4 && windSpeed <= 32.6)
            {
                WindDescription = "Storm";
            }
            else if (windSpeed > 32.6)
            {
                WindDescription = "Orkan";
            }
            OnPropertyChanged(nameof(WindDescription));
        }
        private async void LoadWeatherData()
        {
            string uri = "v1/weather?lat=58.673222&lon=17.074500";
            WeatherData = await WeatherDataManager.GetWeatherAsync(uri);
            if (WeatherData != null)
            {
                SetWindDesciption(WeatherData.WindSpeed);
            }
            else
            {
                WindDescription = "Null";
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyChanged)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyChanged));
        }

        
        
    }
}


