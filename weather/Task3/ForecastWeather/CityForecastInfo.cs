using Newtonsoft.Json;

namespace Task3.ForecastWeather
{
    public class CityInfo
    {
        [JsonProperty("name")] public string Name;
        [JsonProperty("country")] public string Country;
    }
}