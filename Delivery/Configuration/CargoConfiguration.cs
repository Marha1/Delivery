using Delivery.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Delivery.Configuration
{
    public class CargoConfiguration : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Weight).IsRequired();

            builder.Property(c => c.type).IsRequired();

            builder.HasOne(c => c.Flight)  // Один Cargo связан с одним Flight
             .WithOne(f => f.Cargo)  // Один Flight связан с одним Cargo
             .HasForeignKey<Cargo>(c => c.FlightId)  // Внешний ключ в Cargo
             .OnDelete(DeleteBehavior.Cascade);  // 
        }
    }
}
