using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AccountingAppV3.Data
{
    class WeatherDataManager
    {
        private static readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://api.api-ninjas.com/")
        };
        static WeatherDataManager()
        {
            client.DefaultRequestHeaders.Add("X-Api-Key", "qFTcnM1VnXVBE89KpfAgKg==5UGGgBhwmjG7Xgf8");
        }

        public static async Task<Models.Weather?> GetWeatherAsync(string uri)
        {           
            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Models.Weather>(responseString);
            }
            else
            {
                return null;
            }
            
        }
    }
}
