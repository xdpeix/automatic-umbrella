using Newtonsoft.Json;

namespace Task3.CurrentWeather
{
    public class SysInfo
    {
        [JsonProperty("country")] public string Country;
    }
}