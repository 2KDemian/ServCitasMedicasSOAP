using Microsoft.EntityFrameworkCore;
using ServCitasMedicasSOAP.Models;

namespace ServCitasMedicasSOAP.Data
{
    public class CitasMedicasDBContext : DbContext
    {
        public CitasMedicasDBContext(DbContextOptions<CitasMedicasDBContext> options)
            : base(options)
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Cita> Citas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<Paciente>().ToTable("Paciente");
            modelBuilder.Entity<Cita>().ToTable("Cita");
        }
    }
}
