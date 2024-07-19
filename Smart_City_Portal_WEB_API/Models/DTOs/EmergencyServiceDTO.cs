namespace Smart_City_Portal_WEB_API.Models.DTOs
{
    public class EmergencyServiceDTO
    {
        public int Id { get; set; }
        public string ServiceName { get; set; } = null!;
        public string ContactNumber { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
