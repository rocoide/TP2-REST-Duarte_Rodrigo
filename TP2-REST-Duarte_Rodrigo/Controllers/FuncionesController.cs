using Application.Excepcions;
using Application.Interface.Funciones;
using Application.Interface.Tickets;
using Application.Model.DTO;
using Application.Model.Response;
using Application.Model.Response.Funciones;
using Application.Model.Response.Tickets;
using Microsoft.AspNetCore.Mvc;

namespace TP2_REST_Duarte_Rodrigo.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FuncionController : ControllerBase
    {
        private readonly IFuncionService ServiceFunciones;
        private readonly ITicketService ServiceTickets;

        public FuncionController(IFuncionService ServiceFunciones, ITicketService ServiceTickets)
        {
            this.ServiceFunciones = ServiceFunciones;
            this.ServiceTickets = ServiceTickets;
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<FuncionResponse>), 200)]
        public async Task<IActionResult> GetFunciones(string? Titulo = null, string? Fecha = null, int? GeneroId = null)
        {
            try
            {
                List<FuncionResponse> ListaResponse = await ServiceFunciones.GetFunciones(Titulo, Fecha, GeneroId);
                return Ok(ListaResponse);
            }
            catch (Exception)
            {
                BadResponse BadResponse = new BadResponse
                {
                    Message = "Ingrese la fecha en un formato valido."
                };
                return BadRequest(BadResponse);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddFuncion(FuncionDTO FuncionDTO)
        {
            try
            {
                FuncionResponse? Resultado = await ServiceFunciones.AddFuncion(FuncionDTO);
                return new JsonResult(Resultado) { StatusCode = 201 };
            }
            catch (ConflicExcepcion Ex)
            {
                BadResponse BadResponse = new BadResponse
                {
                    Message = Ex.Message
                };
                return Conflict(BadResponse);
            }
            catch (Exception Ex)
            {
                BadResponse BadResponse = new BadResponse
                {
                    Message = Ex.Message
                };
                return BadRequest(BadResponse);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFuncionByID(int id)
        {
            try
            {
                FuncionResponse FuncionResponse = await ServiceFunciones.GetFuncionById(id);
                return Ok(FuncionResponse);
            }
            catch (FormatException Ex)
            {
                BadResponse BadResponse = new BadResponse
                {
                    Message = Ex.Message
                };
                return BadRequest(BadResponse);
            }
            catch (ConflicExcepcion Ex)
            {
                BadResponse BadResponse = new BadResponse
                {
                    Message = Ex.Message
                };
                return NotFound(BadResponse);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFuncion(int id)
        {
            try
            {
                FuncionRemoveResponse Resultado = await ServiceFunciones.RemoveFuncion(id);
                return Ok(Resultado);
            }
            catch (FormatException Ex)
            {
                BadResponse BadResponse = new BadResponse
                {
                    Message = Ex.Message
                };
                return BadRequest(BadResponse);
            }
            catch (NotFoundExcepcion Ex)
            {
                BadResponse BadResponse = new BadResponse
                {
                    Message = Ex.Message
                };
                return NotFound(BadResponse);
            }
            catch (ConflicExcepcion Ex)
            {
                BadResponse BadResponse = new BadResponse
                {
                    Message = Ex.Message
                };
                return Conflict(BadResponse);
            }
        }

        [HttpGet("{id}/tickets")]
        public async Task<IActionResult> GetCantTicketsDisponibles(int id)
        {
            try
            {
                TicketCantidadResponse TicketCantidadResponse = await ServiceTickets.GetCantTicketsDisponibles(id);
                return Ok(TicketCantidadResponse);
            }
            catch (FormatException)
            {
                BadResponse BadResponse = new BadResponse
                {
                    Message = "Por favor ingrese un valor en formato numerico en cantidad."
                };
                return BadRequest(BadResponse);
            }
            catch (NotFoundExcepcion Ex)
            {
                BadResponse BadResponse = new BadResponse
                {
                    Message = Ex.Message
                };
                return NotFound(BadResponse);
            }
        }

        [HttpPost("{id}/tickets")]
        public async Task<IActionResult> AddTicket(TicketDTO TicketDTO, int id)
        {
            try
            {
                TicketResponse TicketResponse = await ServiceTickets.AddTicket(TicketDTO, id);
                return new JsonResult(TicketResponse) { StatusCode = 201 };
            }
            catch (NotFoundExcepcion Ex)
            {
                BadResponse BadResponse = new BadResponse
                {
                    Message = Ex.Message
                };
                return NotFound(BadResponse);
            }
            catch (Exception Ex)
            {
                BadResponse BadResponse = new BadResponse
                {
                    Message = Ex.Message
                };
                return BadRequest(BadResponse);
            }
        }

    }
}
