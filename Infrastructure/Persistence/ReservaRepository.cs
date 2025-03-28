using GestionDeReservas.Application.DTOs;
using GestionDeReservas.Application.Features.Interfaces;
using GestionDeReservas.Domain;
using Microsoft.EntityFrameworkCore;

namespace GestionDeReservas.Infrastructure.Persistence
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly AppDbContext _context;

        public ReservaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddReserva(Reserva reserva)
        {
            _context.Reserva.Add(reserva);
            await _context.SaveChangesAsync();

            return await _context.Reserva
                .OrderByDescending(r => r.Id)
                .Select(r => r.Id)
                .FirstOrDefaultAsync();
        }

        public async Task EliminarReserva(int id)
        {
            var reserva = await _context.Reserva.FirstOrDefaultAsync(r => r.Id == id);

            if (reserva != null)
            {
                _context.Reserva.Remove(reserva);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ReservaDTO>> GetAll()
        {
            return await _context.Reserva
    .Include(r => r.Servicio)
    .Include(r => r.ReservaHorarios)
        .ThenInclude(rh => rh.Horario)
    .Where(r => r.ReservaHorarios.Any()) 
    .Select(r => new ReservaDTO
    {
        Id = r.Id,
        Cliente = r.Cliente,
        Servicio = r.Servicio.Descripcion,
        Fecha = r.ReservaHorarios.FirstOrDefault().Fecha,
        Hora = r.ReservaHorarios.FirstOrDefault().Horario.Hora 
    })
    .ToListAsync();

        }
    }
}
