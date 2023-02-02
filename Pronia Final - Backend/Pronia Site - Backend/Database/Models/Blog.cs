using Pronia_Site___Backend.Database.Models.Common;

namespace Pronia_Site___Backend.Database.Models
{
    public class Blog : BaseEntity<int>, IAuditable
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? From { get; set; }

        public Guid? AdminId { get; set; }
        public User? Admin { get; set; }    

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<BlogImage>? BlogImages { get; set; }
        public List<BlogVideo>? BlogVideos { get; set; }
        public List<BlogTag>? BlogTags { get; set; }
    }
}
