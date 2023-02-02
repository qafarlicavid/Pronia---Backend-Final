using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pronia_Site___Backend.Database.Models;

namespace Pronia_Site___Backend.Database.Configurations
{
    public class BasketProductConfigurations : IEntityTypeConfiguration<BasketProduct>
    {
        public void Configure(EntityTypeBuilder<BasketProduct> builder)
        {
            builder
                .ToTable("BasketProducts");

            builder
              .HasOne(b => b.Basket)
              .WithMany(basket => basket.BasketProducts)
              .HasForeignKey(bi => bi.BasketId);

            builder
              .HasOne(p => p.Product)
              .WithMany(product => product.BasketProducts)
              .HasForeignKey(pi => pi.ProductId);

        }
    }
}
