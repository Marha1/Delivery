using Delivery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Delivery.Configuration
{
    public class DriverConfiguration : IEntityTypeConfiguration<Models.Driver>
    {
        public void Configure(EntityTypeBuilder<Models.Driver> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(d => d.Surname)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(d => d.LastName)
                   .HasMaxLength(100);

            builder.Property(d => d.Age)
                   .IsRequired();

            builder.Property(d => d.Experience)
                   .IsRequired();

            // Связь с Auth (один к одному)
            builder.HasOne(d => d.Auth)
                   .WithOne(a => a.Driver) // Один Auth имеет одного Driver
                   .HasForeignKey<Models.Driver>(d => d.AuthId) // Внешний ключ в таблице Driver
                   .OnDelete(DeleteBehavior.Cascade);

            // Связь с Flight (один к одному)
            builder.HasOne(d => d.CurrentFlight)
                   .WithOne(f => f.Driver)
                   .HasForeignKey<Models.Driver>(d => d.FlightId)
                   .OnDelete(DeleteBehavior.SetNull); // Или Cascade, в зависимости от вашей логики
        }
    }
}
