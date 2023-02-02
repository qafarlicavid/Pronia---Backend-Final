using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pronia_Site___Backend.Database.Models;

namespace Pronia_Site___Backend.Database.Configurations
{
    public class BlogVideoConfigurations : IEntityTypeConfiguration<BlogVideo>
    {
        public void Configure(EntityTypeBuilder<BlogVideo> builder)
        {
            builder
                .ToTable("BlogVideos");

            builder
                .HasOne(bv => bv.Blog)
                .WithMany(b => b.BlogVideos)
                .HasForeignKey(bv => bv.BlogId);
        }
    }
}
