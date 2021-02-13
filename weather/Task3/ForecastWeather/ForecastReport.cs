using System.Collections.Generic;
using Newtonsoft.Json;

namespace Task3.ForecastWeather
{
    public class ForecastReport
    {
        [JsonProperty("list")] public static List<ForecastFeatures> Features;

        [JsonProperty("city")] public CityInfo City;

    }
}