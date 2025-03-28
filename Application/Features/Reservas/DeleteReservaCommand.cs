using GestionDeReservas.Application.Features.Interfaces;
using GestionDeReservas.Domain;
using MediatR;

namespace GestionDeReservas.Application.Features.Reservas
{
    public class DeleteReservaCommand : IRequest
    {
        public int Id { get; set; }


        public class DeleteReservaHandler : IRequestHandler<DeleteReservaCommand>
        {
            private readonly IReservaRepository _reservaRepository;

            public DeleteReservaHandler(IReservaRepository reservaRepository)
            {
                _reservaRepository = reservaRepository;
            }

            public async Task Handle(DeleteReservaCommand request, CancellationToken cancellationToken)
            {
                await _reservaRepository.EliminarReserva(request.Id);
            }
        }
    }
}
