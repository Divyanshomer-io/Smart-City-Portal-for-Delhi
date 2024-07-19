namespace Smart_City_Portal_WEB_API.Models.DTOs
{
    public class WeatherUpdateDTO
    {
        public int Id { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public string WeatherDescription { get; set; } = null!;
        public DateTime Timestamp { get; set; }
    
}
}
