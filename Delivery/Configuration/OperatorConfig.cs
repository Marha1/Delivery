using Delivery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Delivery.Configuration
{
    public class OperatorConfig : IEntityTypeConfiguration<Operator>
    {
        public void Configure(EntityTypeBuilder<Operator> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(o => o.Surname)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(o => o.LastName)
                   .HasMaxLength(100);

            builder.Property(o => o.Age)
                   .IsRequired();

            builder.Property(o => o.Experience)
                   .IsRequired();

            // Связь с Auth (один к одному)
            builder.HasOne(o => o.Auth)
                   .WithOne(a => a.Operator) // Один Auth связан с одним Operator
                   .HasForeignKey<Operator>(o => o.AuthId) // Указание внешнего ключа
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
