using Newtonsoft.Json;

namespace Task3.ForecastWeather
{
    public class WindInfo
    {
        [JsonProperty("speed")] public float Speed;
        [JsonProperty("deg")] public float Degrees;
    }
}