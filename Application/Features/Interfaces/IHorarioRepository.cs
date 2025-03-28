using GestionDeReservas.Domain;

namespace GestionDeReservas.Application.Features.Interfaces
{
    public interface IHorarioRepository
    {
        Task<List<Horario>> GetHorariosDisponibles(int idServicio, DateTime fecha);
    }
}
