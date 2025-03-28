using GestionDeReservas.Application.DTOs;
using GestionDeReservas.Application.Features.Horarios;
using GestionDeReservas.Application.Features.Servicios;
using GestionDeReservas.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeReservas.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HorarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HorarioController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<Horario>>> GetHorariosDisponibles([FromQuery] HorarioRequestDTO request)
        {
            try
            {
                var query = new GetHorarioQuery
                {
                    IdServicio = request.IdServicio,
                    Fecha = request.Fecha
                };

                var horarios = await _mediator.Send(query);
                return Ok(horarios);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
