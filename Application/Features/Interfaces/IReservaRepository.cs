using GestionDeReservas.Application.DTOs;
using GestionDeReservas.Domain;

namespace GestionDeReservas.Application.Features.Interfaces
{
    public interface IReservaRepository
    {
        Task<List<ReservaDTO>> GetAll();
        Task<int> AddReserva(Reserva reserva);
        Task EliminarReserva(int idReserva);
    }
}
