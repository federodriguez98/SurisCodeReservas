using GestionDeReservas.Application.Features.Interfaces;
using GestionDeReservas.Domain;
using Microsoft.EntityFrameworkCore;

namespace GestionDeReservas.Infrastructure.Persistence
{
    public class HorarioRepository : IHorarioRepository
    {
        private readonly AppDbContext _context;

        public HorarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Horario>> GetHorariosDisponibles(int idServicio, DateTime date)
        {
            // 1. Obtener los IdReserva del servicio
            var reservasDelServicio = await _context.Reserva
                .Where(r => r.IdServicio == idServicio)
                .Select(r => r.Id)
                .ToListAsync();

            // 2. Obtener los IdHorario ya reservados para esa fecha y ese servicio
            var horariosReservados = await _context.ReservaHorario
                .Where(rh => reservasDelServicio.Contains(rh.IdReserva) && rh.Fecha == date)
                .Select(rh => rh.IdHorario)
                .Distinct()
                .ToListAsync();

            // 3. Devolver los horarios que NO están en la lista de reservados
            var horariosDisponibles = await _context.Horario
                .Where(h => !horariosReservados.Contains(h.Id))
                .ToListAsync();

            return horariosDisponibles;
        }
    }
}
