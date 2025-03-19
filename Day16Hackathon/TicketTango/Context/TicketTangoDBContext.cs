using Microsoft.EntityFrameworkCore;
using TicketTango.Models;

namespace TicketTango.Context
{
    public class TicketTangoDBContext : DbContext
    {
        // Constructor
        public TicketTangoDBContext(DbContextOptions<TicketTangoDBContext> options) : base(options) { } // Conn obj

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasAlternateKey(u => u.Email); // For unique Email
        }

        // Table Set Properties
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<TicketBooking> TicketBookings { get; set; }

    }
}
