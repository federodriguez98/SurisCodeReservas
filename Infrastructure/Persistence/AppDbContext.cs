using GestionDeReservas.Domain;
using Microsoft.EntityFrameworkCore;

namespace GestionDeReservas.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Servicio> Servicio { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
        public DbSet<Horario> Horario { get; set; }
        public DbSet<ReservaHorario> ReservaHorario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReservaHorario>(entity =>
            {
                entity.HasKey(rh => new { rh.IdReserva, rh.IdHorario, rh.Fecha });

                entity.HasOne(rh => rh.Reserva)
                    .WithMany(r => r.ReservaHorarios)
                    .HasForeignKey(rh => rh.IdReserva)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(rh => rh.Horario)
                    .WithMany(h => h.ReservaHorarios)
                    .HasForeignKey(rh => rh.IdHorario)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Servicio)
                .WithMany() 
                .HasForeignKey(r => r.IdServicio);   



            base.OnModelCreating(modelBuilder);
        }
    }
}
