using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pronia_Site___Backend.Database.Models;

namespace Pronia_Site___Backend.Database.Configurations
{
    public class ImageConfigurations : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder
                .ToTable("Images");

            builder
                .HasOne(p => p.Products)
                .WithMany(i => i.Images)
                .HasForeignKey(pi => pi.ProductId);
        }
    }
}
