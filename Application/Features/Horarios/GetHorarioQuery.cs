using GestionDeReservas.Application.DTOs;
using GestionDeReservas.Application.Features.Interfaces;
using GestionDeReservas.Application.Features.Reservas;
using GestionDeReservas.Domain;
using MediatR;

namespace GestionDeReservas.Application.Features.Horarios
{
    public class GetHorarioQuery : IRequest<List<Horario>>
    {
        public int IdServicio { get; set; }
        public DateTime Fecha { get; set; }


    public class GetHorarioHandler : IRequestHandler<GetHorarioQuery, List<Horario>>
    {
        private readonly IHorarioRepository _horarioRepository;

        public GetHorarioHandler(IHorarioRepository horarioRepository)
        {
                _horarioRepository = horarioRepository;
        }

        public async Task<List<Horario>> Handle(GetHorarioQuery request, CancellationToken cancellationToken)
        {
            return await _horarioRepository.GetHorariosDisponibles(request.IdServicio, request.Fecha);
        }
    }
}
}
