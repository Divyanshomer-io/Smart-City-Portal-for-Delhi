using System;
using System.Collections.Generic;

namespace Smart_City_Portal_WEB_API.Models
{
    public partial class EmergencyService
    {
        public int Id { get; set; }
        public string ServiceName { get; set; } = null!;
        public string ContactNumber { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
