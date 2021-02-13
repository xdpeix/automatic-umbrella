using Newtonsoft.Json;

namespace Task3.ForecastWeather
{
    public class WeatherInfo
    {
        [JsonProperty("id")] public int Id;
        [JsonProperty("main")] public string Main;
        [JsonProperty("icon")] public string Icon;
    }
}