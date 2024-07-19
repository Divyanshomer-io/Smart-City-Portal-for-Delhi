using System;
using System.Collections.Generic;

namespace Smart_City_Portal_WEB_API.Models

{
    public partial class LocalNews
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public int? AuthorId { get; set; }
        public DateTime PublishedAt { get; set; }

        public string? Image { get; set; }

        public virtual User? Author { get; set; }
    }
}
