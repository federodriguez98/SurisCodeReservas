using GestionDeReservas.Application.Features.Interfaces;
using GestionDeReservas.Domain;
using MediatR;

namespace GestionDeReservas.Application.Features.Servicios
{
    public class GetServicioQuery : IRequest<List<Servicio>>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }


        public class GetServicioHandler : IRequestHandler<GetServicioQuery, List<Servicio>>
        {
            private readonly IServicioRepository _servicioRepository;

            public GetServicioHandler(IServicioRepository servicioRepository)
            {
                _servicioRepository = servicioRepository;
            }

            public async Task<List<Servicio>> Handle(GetServicioQuery request, CancellationToken cancellationToken)
            {
                return await _servicioRepository.GetAll();
            }
        }
    }
}
