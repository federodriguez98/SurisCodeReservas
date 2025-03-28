using GestionDeReservas.Application.DTOs;
using GestionDeReservas.Application.Features.ReservaHorario;
using GestionDeReservas.Domain;

namespace GestionDeReservas.Application.Features.Interfaces
{
    public interface IReservaHorarioRepository
    {
        Task<int> AddReservaHorario(Domain.ReservaHorario reservahorario);
        Task<Domain.ReservaHorario> ValidacionClienteFecha(GetReservaHorarioQuery request);
        Task<Domain.ReservaHorario> ValidacionFechaHoraServicio(GetReservaHorarioServicioQuery request);
    }
}
