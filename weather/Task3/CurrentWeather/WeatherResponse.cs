using Newtonsoft.Json;

namespace Task3.CurrentWeather
{
    internal class WeatherResponse
    {
        [JsonProperty("main")] public MainInfo Main;

        [JsonProperty("weather")] public WeatherInfo[] Weather;

        [JsonProperty("name")] public string Name;

        [JsonProperty("sys")] public SysInfo Sys;

        [JsonProperty("wind")] public WindInfo Wind;

        [JsonProperty("visibility")] public double Visibility;
    }
}