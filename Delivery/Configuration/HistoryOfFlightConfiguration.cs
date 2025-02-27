using Delivery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Delivery.Configuration
{
    public class HistoryOfFlightConfiguration : IEntityTypeConfiguration<HistoryOfFlight>
    {
        public void Configure(EntityTypeBuilder<HistoryOfFlight> builder)
        {
            builder.Property(h => h.Id)
                .ValueGeneratedOnAdd(); // Добавляем автоинкремент
            builder.HasOne(h => h.Driver)
                .WithMany(d => d.HistoryOfFlight) 
                .HasForeignKey(h => h.DriverId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }


}
