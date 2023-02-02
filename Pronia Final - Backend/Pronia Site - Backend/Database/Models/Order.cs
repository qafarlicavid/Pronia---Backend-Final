using Pronia_Site___Backend.Database.Models.Common;
using Pronia_Site___Backend.Database.Models.Enums;

namespace Pronia_Site___Backend.Database.Models
{
    public class Order : BaseEntity<string>, IAuditable
    {
        public string? Id { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public OrderStatus Status { get; set; }
        public decimal SumTotalPrice { get; set; }

        public List<OrderProduct>? OrderProducts { get; set; }

    }
}
