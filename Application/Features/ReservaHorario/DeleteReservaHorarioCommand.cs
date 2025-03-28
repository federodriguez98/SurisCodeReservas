using GestionDeReservas.Application.Features.Interfaces;
using GestionDeReservas.Application.Features.Reservas;
using MediatR;

namespace GestionDeReservas.Application.Features.ReservaHorario
{
    public class DeleteReservaHorarioCommand : IRequest
    {
        public int Id { get; set; }


        public class DeleteReservaHorarioHandler : IRequestHandler<DeleteReservaHorarioCommand>
        {
            private readonly IReservaHorarioRepository _reservaHorarioRepository;

            public DeleteReservaHorarioHandler(IReservaHorarioRepository reservaHorarioRepository)
            {
                _reservaHorarioRepository = reservaHorarioRepository;
            }

            public async Task Handle(DeleteReservaHorarioCommand request, CancellationToken cancellationToken)
            {
                await _reservaHorarioRepository.EliminarReservaHorario(request.Id);
            }
        }
    }
}
