using GestionDeReservas.Application.DTOs;
using GestionDeReservas.Application.Features.Interfaces;
using GestionDeReservas.Application.Features.Reservas;
using MediatR;

namespace GestionDeReservas.Application.Features.ReservaHorario
{
    public class GetReservaHorarioQuery : IRequest<Domain.ReservaHorario>
    {
        public string Cliente { get; set; }
        public DateTime Fecha { get; set; }


        public class GetReservaHorarioHandler : IRequestHandler<GetReservaHorarioQuery, Domain.ReservaHorario>
        {
            private readonly IReservaHorarioRepository _reservaHorarioRepository;

            public GetReservaHorarioHandler(IReservaHorarioRepository reservaHorarioRepository)
            {
                _reservaHorarioRepository = reservaHorarioRepository;
            }

            public async Task<Domain.ReservaHorario> Handle(GetReservaHorarioQuery request, CancellationToken cancellationToken)
            {
                return await _reservaHorarioRepository.ValidacionClienteFecha(request);
            }
        }
    }
}
