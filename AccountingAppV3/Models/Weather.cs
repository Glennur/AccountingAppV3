﻿using System.Text.Json.Serialization;

namespace AccountingAppV3.Models
{
    public class Weather
    {
        [JsonPropertyName("wind_speed")]
        public float WindSpeed { get; set; }
        [JsonPropertyName("wind_degrees")]
        public int WindDegrees { get; set; }
        [JsonPropertyName("temp")]
        public int Temp { get; set; }
        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
        [JsonPropertyName("sunset")]
        public int Sunset { get; set; }
        [JsonPropertyName("min_temp")]
        public int MinTemp { get; set; }
        [JsonPropertyName("cloud_pct")]
        public int CloudPct { get; set; }
        [JsonPropertyName("feels_like")]
        public int FeelsLike { get; set; }
        [JsonPropertyName("sunrise")]
        public int Sunrise { get; set; }
        [JsonPropertyName("max_temp")]
        public int MaxTemp { get; set; }
    }
}
