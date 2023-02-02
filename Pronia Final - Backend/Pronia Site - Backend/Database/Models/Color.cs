using Pronia_Site___Backend.Database.Models.Common;

namespace Pronia_Site___Backend.Database.Models
{
    public class Color : BaseEntity<int>, IAuditable
    {
        public string? Name { get; set; }

        public List<ProductColor>? ProductColors { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
