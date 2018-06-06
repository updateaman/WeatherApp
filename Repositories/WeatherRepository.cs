using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Repositories.Models;

namespace Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly HttpClient _httpClient;

        public WeatherRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Weather> GetWeatherAsync(string cityName)
        {
            var result = await _httpClient.GetAsync("data/2.5/forecast?q=London,uk&appid=b6907d289e10d714a6e88b30761fae22");
            var rString = await result.Content.ReadAsStringAsync();
            var weather = JsonConvert.DeserializeObject<Weather>(rString);
            return weather;
        }

        public async Task<string> GetWeatherJsonAsync(string cityName)
        {
            var result = await _httpClient.GetAsync("data/2.5/forecast?q=London,uk&appid=b6907d289e10d714a6e88b30761fae22");
            var rString = await result.Content.ReadAsStringAsync();
            return rString;
        }
    }

    public interface IWeatherRepository
    {
        Task<Weather> GetWeatherAsync(string cityName);
        Task<string> GetWeatherJsonAsync(string cityName);
    }
}
