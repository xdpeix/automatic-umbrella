﻿using Newtonsoft.Json;

namespace Task3.CurrentWeather
{
    internal class MainInfo
    {
        [JsonProperty("temp")] public float Temp;
        [JsonProperty("humidity")] public int Humidity;
        [JsonProperty("pressure")] public int Pressure;
        [JsonProperty("feels_like")] public float TempFeelsLike;
    }
}