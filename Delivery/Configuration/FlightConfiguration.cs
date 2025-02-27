using Delivery.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Configuration
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(f => f.DispatchDate)
                   .IsRequired();

            builder.Property(f => f.ArrivalDate)
                   .IsRequired();

            builder.Property(f => f.Status)
                   .IsRequired();
            builder.Property(f => f.StartingPoint).IsRequired();
            builder.Property(f => f.EndPoint).IsRequired();
            


            // Связь с Driver (один к одному)
            builder.HasOne(f => f.Driver)
                   .WithOne(d => d.CurrentFlight)
                   .HasForeignKey<Flight>(f => f.DriverId)  // Связь с водителем
                   .OnDelete(DeleteBehavior.SetNull);  // Или Cascade
        }
    }

}
