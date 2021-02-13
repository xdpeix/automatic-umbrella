using System;
using Newtonsoft.Json;

namespace Task3.ForecastWeather
{
    public class ForecastFeatures
    {
        [JsonProperty("main")] public MainInfo Main;

        [JsonProperty("weather")] public WeatherInfo[] Weather;

        [JsonProperty("wind")] public WindInfo Wind;

        [JsonProperty("dt_txt")] public DateTime Dt;

        [JsonProperty("visibility")] public int Visibility;

        [JsonProperty("city")] public CityInfo City;
    }
}