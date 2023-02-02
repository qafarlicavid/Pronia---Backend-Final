using Pronia_Site___Backend.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pronia_Site___Backend.Database.Configurations
{
    public class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
               .HasOne(b => b.User)
               .WithMany(a => a.Orders)
               .HasForeignKey(b => b.UserId);
        }
    }
}
