using Domain.Category;
using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .HasConversion(
            name => name.Name,
            // Ask Always We Need To have a Create Method In Vo?! Answer Must Be yes But
            // Need To Sure...
            value => ProductName.Create(value)

            )
            .HasColumnName("Name")
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(p => p.Price)
            .HasConversion(
            price=>price.Value,
            value => ProductPrice.Create(value)
            )
            .HasColumnName("Price")
            .IsRequired()
            .HasColumnType("bigint");

        builder.Property(p=>p.Description)
            .HasConversion(
            desc => desc.Description,
            value => DescriptionProduct.Create(value)
            )
            .HasColumnName("Description")
            .IsRequired()
            .HasMaxLength(500);

        // Tomorrow Ask Mr.Shiekh About Fk-Only With HasOne/ToMany
        builder.Property(p => p.CategoryId)
            .IsRequired();

        //builder.HasOne<Category>()
        //    .WithMany()
        //    .HasForeignKey(p => p.CategoryId);

    }
}
