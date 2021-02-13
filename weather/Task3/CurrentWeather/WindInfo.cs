using Newtonsoft.Json;

namespace Task3.CurrentWeather
{
    public class WindInfo
    {
        [JsonProperty("speed")] public float Speed;
        [JsonProperty("deg")] public int Deg;
    }
}