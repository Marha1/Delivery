using Delivery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Configuration
{
    public class AuthConfiguration : IEntityTypeConfiguration<Auth>
    {
        public void Configure(EntityTypeBuilder<Auth> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Login)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(a => a.Password)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(a => a.Role)
                   .IsRequired();

            // Настройка связи с оператором
            builder.HasOne(a => a.Operator)
                   .WithOne(o => o.Auth)
                   .HasForeignKey<Operator>(o => o.AuthId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Настройка связи с водителем
            builder.HasOne(a => a.Driver)
                   .WithOne(d => d.Auth) // Один Auth связан с одним Driver
                   .HasForeignKey<Models.Driver>(d => d.AuthId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
