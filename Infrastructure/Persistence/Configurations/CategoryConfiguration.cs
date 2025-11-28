using Domain.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categoryies");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .HasConversion(
            name => name.Name,
            value => CategoryName.Create(value)
            )
            .IsRequired()
            .HasColumnName("Name")
            .HasMaxLength(150);
    }
}
