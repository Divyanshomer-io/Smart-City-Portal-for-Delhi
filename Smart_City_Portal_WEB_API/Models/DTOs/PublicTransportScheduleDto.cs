namespace Smart_City_Portal_WEB_API.Models.DTOs
{
    public class PublicTransportScheduleDto
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Frequency { get; set; }
    }
}
