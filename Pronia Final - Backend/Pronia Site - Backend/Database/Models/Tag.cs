using Pronia_Site___Backend.Database.Models.Common;

namespace Pronia_Site___Backend.Database.Models
{
    public class Tag : BaseEntity<int>, IAuditable
    {
        public string? Title { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
       
        public List<ProductTag>? ProductTags { get; set; }
        public List<BlogTag>? BlogTags { get; set; }
    }
}
