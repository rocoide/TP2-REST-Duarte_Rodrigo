using Application.Interface.Funciones;
using Application.Interface.Tickets;
using Application.Model.DTO;
using Application.Model.Response;
using Microsoft.AspNetCore.Mvc;

namespace TP2_REST_Duarte_Rodrigo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionesController : ControllerBase
    {
        private readonly IFuncionService _serviceFunciones;
        private readonly ITicketService _serviceTickets;

        public FuncionesController(IFuncionService serviceFunciones, ITicketService serviceTickets)
        {
            _serviceFunciones = serviceFunciones;
            _serviceTickets = serviceTickets;
        }




        [HttpGet("v1/Funcion")]
        public async Task<IActionResult> getFunciones(string titulo = null, string fecha = null, int? generoID = null)
        {
            try
            {
                List<FuncionResponse> lista = null;
                List<FuncionResponse> listaFinal = null;
                //sin filtro, devuelve todas las funciones
                if ((titulo == null) && (fecha == null) && (generoID == null))
                {
                    listaFinal = await _serviceFunciones.getAllFunciones();
                }
                if (titulo != null)
                {
                    lista = await _serviceFunciones.getFuncionesByTitulo(titulo);
                    listaFinal = lista;
                }
                if (fecha != null)
                {
                    DateTime fech = DateTime.Parse(fecha);
                    lista = await _serviceFunciones.getFuncionesByFecha(fech);
                    if (listaFinal != null)
                    {
                        listaFinal = await _serviceFunciones.compararFuncionResponse(listaFinal, lista);
                    }
                    else
                    {
                        listaFinal = lista;
                    }
                }
                if (generoID != null)
                {
                    lista = await _serviceFunciones.getFuncionesByGenero(generoID);
                    if (listaFinal != null)
                    {
                        listaFinal = await _serviceFunciones.compararFuncionResponse(listaFinal, lista);
                    }
                    else
                    {
                        listaFinal = lista;
                    }
                }
                if (listaFinal.Count != 0)
                {
                    return new JsonResult(listaFinal) { StatusCode = 200 };
                }
                else
                {
                    Response.Headers.Add("Motivo", "No hay funciones con esos filtros.");
                    return new JsonResult("No se encontraron funciones.") { StatusCode = 404 };
                }
            }
            catch (Exception)
            {
                return new JsonResult("Ingrese la fecha en el formato dd-mm.") { StatusCode = 400 };
            }
        }






        [HttpPost("v1/Funcion")]
        public async Task<IActionResult> AddFuncion(FuncionIdDTO funcionIdDTO)
        {
            try
            {
                FuncionResponse resultado = await _serviceFunciones.AddFuncion(funcionIdDTO);
                if (resultado != null)
                {
                    return new JsonResult(resultado) { StatusCode = 201 };
                }
                else
                {
                    return new JsonResult("No se pudo agregar correctamente la funcion.") { StatusCode = 409 };
                }
            }
            catch (Exception ex)
            {
                return new JsonResult("Por favor ingrese valores validos en los campos") { StatusCode = 400 };
            }
        }




        [HttpGet("v1/Funcion/{id}")]
        public async Task<IActionResult> getFuncionByID(int id)
        {
            try
            {
                FuncionResponse? funcionDTO = await _serviceFunciones.getFuncionByID(id);
                if (funcionDTO == null)
                {
                    return NotFound("Funcion no encontrada.");
                }
                else
                {
                    return new JsonResult(funcionDTO) { StatusCode = 200 };
                }
            }
            catch (Exception ex)
            {
                return new JsonResult("Por favor ingrese los campos en el un formato correspondientes.") { StatusCode = 400 };
            }
        }




        [HttpDelete("v1/Funcion/{id}")]
        public async Task<IActionResult> removeFuncion(int id)
        {
            try
            {
                FuncionRemoveResponse? resultado = await _serviceFunciones.removeFuncion(id);
                if (resultado == null)
                {
                    return new JsonResult("No se encontre la funcion a eliminar.") { StatusCode = 404 };
                }
                else
                {
                    if (resultado.funcionId == 0)
                    {
                        return new JsonResult(resultado) { StatusCode = 200 };
                    }
                    else
                    {
                        return new JsonResult("No se puede eliminar la funcion debido a que tiene entradas vendidas") { StatusCode = 409 };
                    }
                }
            }
            catch (FormatException)
            {
                return new JsonResult("Por favor ingrese los campos en el formato correspondientes.") { StatusCode = 400 };
            }

        }





        [HttpGet("/api/v1/Funcion/{id}/tickets")]
        public async Task<IActionResult> getCantTicketsDisponibles(int id)
        {
            try
            {
                int? resultado = await _serviceTickets.getCantTicketsDisponibles(id);
                if (resultado == null)
                {
                    return NotFound("No existe la funcion solicitada.");
                }
                return new JsonResult(resultado) { StatusCode = 200 };
            }
            catch (FormatException)
            {
                return new JsonResult("Por favor llene adecuadamene los campos.");
            }
        }





        [HttpPost("/api/v1/Funcion/{id}/tickets")]
        public async Task<IActionResult> AddTicket(TicketDTO ticketDTO, int id)
        {
            try
            {
                int? tickets_disponibles = await _serviceTickets.getCantTicketsDisponibles(id);
                if (tickets_disponibles == null)
                {
                    return NotFound("No se ha encontrado la funcion.");
                }
                else
                {
                    if (tickets_disponibles < ticketDTO.cantidad)
                    {
                        return Ok("No hay suficientes tickets disponibles para esta funcion.");
                    }
                    else
                    {
                        TicketResponse ticketResponse = await _serviceTickets.AddTicket(ticketDTO, id);
                        return new JsonResult(ticketResponse) { StatusCode = 201 };
                    }
                }
            }
            catch
            {
                return new JsonResult("Por favor ingrese un valor en formato numerico en cantidad");
            }
        }

    }
}
