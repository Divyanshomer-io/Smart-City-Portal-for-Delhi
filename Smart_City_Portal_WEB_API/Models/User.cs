using System;
using System.Collections.Generic;

namespace Smart_City_Portal_WEB_API.Models
{
    public partial class User
    {
        public User()
        {
            LocalNews = new HashSet<LocalNews>();
        }

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime? LastLoginTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<LocalNews> LocalNews { get; set; }
    }
}
