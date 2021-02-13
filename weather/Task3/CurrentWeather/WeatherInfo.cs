using Newtonsoft.Json;

namespace Task3.CurrentWeather
{
    internal class WeatherInfo
    {
        [JsonProperty("id")] public int Id;
        [JsonProperty("main")] public string Main;
        [JsonProperty("icon")] public string Icon;
        [JsonProperty("description")] public string Description;
    }
}