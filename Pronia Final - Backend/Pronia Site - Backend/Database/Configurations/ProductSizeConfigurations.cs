using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pronia_Site___Backend.Database.Models;

namespace Pronia_Site___Backend.Database.Configurations
{
    public class ProductSizeConfigurations : IEntityTypeConfiguration<ProductSize>
    {
        public void Configure(EntityTypeBuilder<ProductSize> builder)
        {
            builder
                .ToTable("ProductSizes");

            builder
                .HasKey(bc => new { bc.ProductId, bc.SizeId});

            builder
               .HasOne(bc => bc.Product)
               .WithMany(p => p.ProductSizes)
               .HasForeignKey(bc => bc.ProductId);

            builder
                .HasOne(bc => bc.Size)
                .WithMany(p => p.ProductSizes)
                .HasForeignKey(bc => bc.SizeId);
        }
    }
}
