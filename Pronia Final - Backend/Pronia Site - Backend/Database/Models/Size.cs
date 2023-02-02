using Pronia_Site___Backend.Database.Models.Common;

namespace Pronia_Site___Backend.Database.Models
{
    public class Size : BaseEntity<int>, IAuditable
    {
        public string? Name { get; set; }

        public List<ProductSize>? ProductSizes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
