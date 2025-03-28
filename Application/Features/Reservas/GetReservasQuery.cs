using GestionDeReservas.Application.DTOs;
using GestionDeReservas.Application.Features.Interfaces;
using GestionDeReservas.Application.Features.Servicios;
using GestionDeReservas.Domain;
using MediatR;

namespace GestionDeReservas.Application.Features.Reservas
{
    public class GetReservasQuery : IRequest<List<ReservaDTO>>
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string Servicio { get; set; }
        public DateOnly Fecha { get; set; }
        public TimeOnly Hora { get; set; }


        public class GetReservasHandler : IRequestHandler<GetReservasQuery, List<ReservaDTO>>
        {
            private readonly IReservaRepository _reservaRepository;

            public GetReservasHandler(IReservaRepository reservaRepository)
            {
                _reservaRepository = reservaRepository;
            }

            public async Task<List<ReservaDTO>> Handle(GetReservasQuery request, CancellationToken cancellationToken)
            {
                return await _reservaRepository.GetAll();
            }
        }
    }
}
