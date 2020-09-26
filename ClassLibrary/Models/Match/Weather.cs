using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models.Match
{
    public class Weather
    {
        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        [JsonProperty("temp_celsius")]
        public int TempCelsius { get; set; }

        [JsonProperty("temp_farenheit")]
        public int TempFarenheit { get; set; }

        [JsonProperty("wind_speed")]
        public int WindSpeed { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
