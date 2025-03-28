using GestionDeReservas.Application.DTOs;
using GestionDeReservas.Application.Features.Servicios;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeReservas.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioController : Controller
    {
        private readonly IMediator _mediator;

        public ServicioController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<ServicioDTO>>> GetReservas()
        {
            var servicios = await _mediator.Send(new GetServicioQuery());
            return Ok(servicios);
        }
    }
}
