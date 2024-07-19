namespace Smart_City_Portal_WEB_API.Models.DTOs
{
    public class LocalNewsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public int? AuthorId { get; set; }
        public DateTime PublishedAt { get; set; }
    }
}