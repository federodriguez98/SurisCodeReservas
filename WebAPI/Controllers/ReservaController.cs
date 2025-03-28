using Azure.Core;
using GestionDeReservas.Application.DTOs;
using GestionDeReservas.Application.Features.Horarios;
using GestionDeReservas.Application.Features.ReservaHorario;
using GestionDeReservas.Application.Features.Reservas;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeReservas.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservaController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<ReservaDTO>>> GetReservas()
        {
            try { 
                var reservas = await _mediator.Send(new GetReservasQuery());
                return Ok(reservas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateReserva(CreateReservaCommand reservas)
        {
            try
            {
                //Valido que este cliente no tenga otra reserva para esta fecha.
                var validacionClienteFecha = new GetReservaHorarioQuery
                {
                    Cliente = reservas.Cliente,
                    Fecha = reservas.Fecha
                };

                if(await _mediator.Send(validacionClienteFecha) != null)
                {
                    return BadRequest("Este cliente ya tiene una reserva para este mismo día");
                }

                //Valido que no exista una reserva para este servicio en el mismo día y horario.
                var validacionHorarioDisponible = new GetReservaHorarioServicioQuery
                {
                    IdServicio = reservas.IdServicio,
                    Fecha = reservas.Fecha,
                    IdHorario = reservas.IdHorario,
                };

                if(await _mediator.Send(validacionHorarioDisponible) != null)
                {
                    return BadRequest("Este servicio en este día y horario ya se encuentra reservado.");
                }


                var idReserva = await _mediator.Send(reservas);
                if (idReserva == null)
                {
                    return BadRequest("No se pudo hacer la reserva");
                }
                var createReservaHorario = new CreateReservaHorarioCommand { 
                    IdHorario = reservas.IdHorario,
                    IdReserva = idReserva,
                    FechaEntrante = reservas.Fecha
                    };
                var idReservaHorario = await _mediator.Send(createReservaHorario);
                if (idReservaHorario == null)
                {
                    return BadRequest("No se pudo hacer la reserva");
                }
                return Ok();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarReserva(int id)
        {
            try
            {
                var deleteReservaHorario = new DeleteReservaHorarioCommand { Id = id };
                await _mediator.Send(deleteReservaHorario);
                var deleteReserva = new DeleteReservaCommand { Id = id };
                await _mediator.Send(deleteReserva);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
