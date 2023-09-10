using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskmanagement.Model;

namespace Taskmanagement.Infrastructure.Persistence.Configuration;
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(x => x.Id);
        builder.HasOne(x=>x.Customer).WithMany(x=>x.Products).HasForeignKey(x=>x.CustomerId).IsRequired(true);
    }
}
