using GestionDeReservas.Application.Features.Interfaces;
using GestionDeReservas.Domain;
using MediatR;

namespace GestionDeReservas.Application.Features.Reservas
{
    public class CreateReservaHorarioCommand : IRequest<int>
    {
        public int IdHorario { get; set; }
        public int IdReserva { get; set; }
        public DateTime FechaEntrante { get; set; }


        public class CreateReservaHorarioHandler : IRequestHandler<CreateReservaHorarioCommand, int>
        {
            private readonly IReservaHorarioRepository _reservaHorarioRepository;

            public CreateReservaHorarioHandler(IReservaHorarioRepository reservaHorarioRepository)
            {
                _reservaHorarioRepository = reservaHorarioRepository;
            }

            public async Task<int> Handle(CreateReservaHorarioCommand request, CancellationToken cancellationToken)
            {
                var reservaHorario = new Domain.ReservaHorario
                {
                    IdHorario = request.IdHorario,
                    IdReserva = request.IdReserva,
                    Fecha = request.FechaEntrante.Date,
                };

                return await _reservaHorarioRepository.AddReservaHorario(reservaHorario);
            }
        }
    }
}
