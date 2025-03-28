using GestionDeReservas.Application.Features.Interfaces;
using GestionDeReservas.Domain;
using MediatR;

namespace GestionDeReservas.Application.Features.Reservas
{
    public class CreateReservaCommand : IRequest<int>
    {
        public int IdServicio { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public int IdHorario { get; set; }


        public class CreateReservaHandler : IRequestHandler<CreateReservaCommand, int>
        {
            private readonly IReservaRepository _reservaRepository;

            public CreateReservaHandler(IReservaRepository reservaRepository)
            {
                _reservaRepository = reservaRepository;
            }

            public async Task<int> Handle(CreateReservaCommand request, CancellationToken cancellationToken)
            {
                var reserva = new Reserva
                {
                    IdServicio = request.IdServicio,
                    Cliente = request.Cliente
                };

                return await _reservaRepository.AddReserva(reserva);
            }
        }
    }
}
