using GestionDeReservas.Application.Features.Interfaces;
using GestionDeReservas.Domain;
using Microsoft.EntityFrameworkCore;

namespace GestionDeReservas.Infrastructure.Persistence
{
    public class ServicioRepository : IServicioRepository
    {
        private readonly AppDbContext _context;

        public ServicioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Servicio>> GetAll()
        {
            return await _context.Servicio.ToListAsync();
        }
    }
}
