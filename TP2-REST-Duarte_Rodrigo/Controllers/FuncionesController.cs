using Application.Interface.Funciones;
using Application.Interface.Tickets;
using Application.Model.DTO;
using Application.Model.Response;
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


        //terminado

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
                var ObjetoAnonimo = new
                {
                    message = "Ingrese la fecha en un formato valido."
                };
                return BadRequest(ObjetoAnonimo);
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
            catch (Exception Ex)
            {
                return Conflict(Ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetFuncionByID(int Id)
        {
            try
            {
                FuncionResponse? FuncionResponse = await ServiceFunciones.GetFuncionById(Id);
                if (FuncionResponse == null)
                {
                    return NotFound("Funcion no encontrada.");
                }
                else
                {
                    return Ok(FuncionResponse);
                }
            }
            catch (Exception)
            {
                var ObjetoAnonimo = new
                {
                    Message = "Por favor ingrese los campos en un formato correspondientes."
                };
                return BadRequest(ObjetoAnonimo); //no llega nunca aca
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveFuncion(int Id)
        {
            try
            {
                FuncionRemoveResponse? Resultado = await ServiceFunciones.RemoveFuncion(Id);
                if (Resultado == null)
                {
                    return new JsonResult("No se encontre la funcion a eliminar.") { StatusCode = 404 };
                }
                else
                {
                    return new JsonResult(Resultado) { StatusCode = 200 };
                }
            }
            catch (FormatException)
            {
                return BadRequest("Por favor ingrese los campos en el formato correspondientes.");
            }
            catch (Exception Ex) 
            {
                return new JsonResult(Ex.Message) { StatusCode = 409 };
            }
        }

        [HttpGet("{Id}/tickets")]
        public async Task<IActionResult> GetCantTicketsDisponibles(int Id)
        {
            try
            {
                int? Resultado = await ServiceTickets.GetCantTicketsDisponibles(Id);
                if (Resultado == null)
                {
                    var ObjetoAnonimo = new
                    {
                        Message = "No existe la funcion " + Id + "."
                    };
                    return NotFound(ObjetoAnonimo);
                }
                else 
                {
                    var ObjetoAnonimo = new
                    {
                        Cantidad = Resultado
                    };
                    return Ok(ObjetoAnonimo);
                }
            }
            catch (FormatException)
            {
                var ObjetoAnonimo = new
                {
                    Message = "Por favor llene adecuadamene los campos."
                };
                return BadRequest(ObjetoAnonimo);
            }
        }





        [HttpPost("{Id}/tickets")]
        public async Task<IActionResult> AddTicket(TicketDTO TicketDTO, int Id)
        {
            try
            {
                int? tickets_disponibles = await ServiceTickets.GetCantTicketsDisponibles(Id);
                if (tickets_disponibles == null)
                {
                    return NotFound("No se ha encontrado la funcion.");
                }
                else
                {
                    if (tickets_disponibles < TicketDTO.Cantidad)
                    {
                        return Ok("No hay suficientes tickets disponibles para esta funcion.");
                    }
                    else
                    {
                        TicketResponse ticketResponse = await ServiceTickets.AddTicket(TicketDTO, Id);
                        return new JsonResult(ticketResponse) { StatusCode = 201 };
                    }
                }
            }
            catch (FormatException)
            {
                var ObjetoAnonimo = new
                {
                    Message = "Por favor ingrese un valor en formato numerico en cantidad."
                };
                return BadRequest(ObjetoAnonimo);
            }
            catch (Exception) 
            {

                return Conflict();
            }
        }

    }
}
