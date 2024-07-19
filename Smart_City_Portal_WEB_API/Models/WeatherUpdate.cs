using System;
using System.Collections.Generic;

namespace Smart_City_Portal_WEB_API.Models
{
    public partial class WeatherUpdate
    {
        public int Id { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public string WeatherDescription { get; set; } = null!;
        public DateTime Timestamp { get; set; }
    }
}
