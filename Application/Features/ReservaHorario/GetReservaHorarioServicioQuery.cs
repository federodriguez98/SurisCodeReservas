using GestionDeReservas.Application.Features.Interfaces;
using MediatR;

namespace GestionDeReservas.Application.Features.ReservaHorario
{
    public class GetReservaHorarioServicioQuery : IRequest<Domain.ReservaHorario>
    {
        public int IdServicio { get; set; }
        public DateTime Fecha { get; set; }
        public int IdHorario { get; set; }


        public class GetReservaHorarioServicioHandler : IRequestHandler<GetReservaHorarioServicioQuery, Domain.ReservaHorario>
        {
            private readonly IReservaHorarioRepository _reservaHorarioRepository;

            public GetReservaHorarioServicioHandler(IReservaHorarioRepository reservaHorarioRepository)
            {
                _reservaHorarioRepository = reservaHorarioRepository;
            }

            public async Task<Domain.ReservaHorario> Handle(GetReservaHorarioServicioQuery request, CancellationToken cancellationToken)
            {
                return await _reservaHorarioRepository.ValidacionFechaHoraServicio(request);
            }
        }
    }
}
