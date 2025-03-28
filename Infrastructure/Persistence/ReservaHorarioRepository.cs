using GestionDeReservas.Application.DTOs;
using GestionDeReservas.Application.Features.Interfaces;
using GestionDeReservas.Application.Features.ReservaHorario;
using GestionDeReservas.Domain;
using Microsoft.EntityFrameworkCore;

namespace GestionDeReservas.Infrastructure.Persistence
{
    public class ReservaHorarioRepository : IReservaHorarioRepository
    {
        private readonly AppDbContext _context;

        public ReservaHorarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ReservaHorario> ValidacionClienteFecha(GetReservaHorarioQuery query)
        {
            return _context.ReservaHorario.Include(r => r.Reserva).FirstOrDefault(x => x.Reserva.Cliente == query.Cliente && x.Fecha == query.Fecha.Date);
        }

        public async Task<ReservaHorario> ValidacionFechaHoraServicio(GetReservaHorarioServicioQuery query)
        {
            return _context.ReservaHorario.Include(r => r.Reserva).FirstOrDefault(x => x.Reserva.IdServicio == query.IdServicio && x.Fecha == query.Fecha && x.IdHorario == query.IdHorario);
        }
        

        public async Task<int> AddReservaHorario(Domain.ReservaHorario reservaHorario)
        {
            _context.ReservaHorario.Add(reservaHorario);
            return await _context.SaveChangesAsync();
        }

        public async Task EliminarReservaHorario(int id)
        {
            var reservaHorario = await _context.ReservaHorario.FirstOrDefaultAsync(r => r.IdReserva == id);

            if (reservaHorario != null)
            {
                _context.ReservaHorario.Remove(reservaHorario);
                await _context.SaveChangesAsync();
            }
        }
    }
}
