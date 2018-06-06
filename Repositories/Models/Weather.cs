using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Repositories.Models
{
    public class Weather
    {
        public City City { get; set; }
    }

    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        [JsonProperty(PropertyName = "coord")]
        public Coordinates Coordinates { get; set; }
    }

    public class Coordinates
    {
        [JsonProperty(PropertyName = "lon")]
        public double Longitude { get; set; }
        [JsonProperty(PropertyName = "lat")]
        public double Latitude { get; set; }
    }
}
