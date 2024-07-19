using System;
using System.Collections.Generic;

namespace Smart_City_Portal_WEB_API.Models
{
    public partial class PublicTransportSchedule
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Frequency { get; set; }

        public string? Pickup { get; set; }

        public string? Destination { get; set; }
    }
}
