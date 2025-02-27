using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery
{
    using Delivery.Configuration;
    using Delivery.Models;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationContext : DbContext
    {
        public DbSet<Auth> Auths { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Models.Driver> Drivers { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<HistoryOfFlight> HistoryOfFlights { get; set; }
        public DbSet<Operator> Operators { get; set; }

        public ApplicationContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(@"host=localhost;port=5432;database=Deliv;username=postgres;password=053352287");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthConfiguration());
            modelBuilder.ApplyConfiguration(new CargoConfiguration());
            modelBuilder.ApplyConfiguration(new DriverConfiguration());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new HistoryOfFlightConfiguration());
            modelBuilder.ApplyConfiguration(new OperatorConfig());
        }
    }

}
