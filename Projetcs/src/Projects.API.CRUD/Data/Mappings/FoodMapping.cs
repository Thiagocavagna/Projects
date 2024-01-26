using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projects.API.CRUD.Domain.Entities;
using Projects.Base.Enumerations;
using System.Reflection.Emit;

namespace Projects.API.CRUD.Data.Mappings
{
    public class FoodMapping : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.ToTable("Food");

            builder.Property(p => p.Id)
                .HasColumnName("FoodId");

            builder.Property(p => p.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnType("varchar(500)");

            builder.Property(a => a.Type)
                .HasConversion(
                a => a.ToString(),
                a => (FoodType)Enum.Parse(typeof(FoodType), a))
                .HasMaxLength(20)
            .IsRequired();

            builder.Property(f => f.Carbohydrate)
                .HasColumnType("decimal(18,2)");

            builder.Property(f => f.Fat)
                .HasColumnType("decimal(18,2)");

            builder.Property(f => f.Protein)
                .HasColumnType("decimal(18,2)");

            builder.HasIndex(builder => builder.Name)
                .IsUnique();
        }
    }
}
