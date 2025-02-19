using Appointment.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Appointment.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<AppointmentForm> AppointmentForm { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppointmentForm>();
        }
    }
}
