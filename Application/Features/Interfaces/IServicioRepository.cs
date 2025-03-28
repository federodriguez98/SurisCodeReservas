using GestionDeReservas.Domain;

namespace GestionDeReservas.Application.Features.Interfaces
{
    public interface IServicioRepository
    {
        Task<List<Servicio>> GetAll();
    }
}
