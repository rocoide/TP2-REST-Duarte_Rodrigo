using Application.Interface.Funciones;
using Application.Interface.Tickets;
using Application.Model.DTO;
using Application.Model.Response;
using Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

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
                    return NoContent();
                }
            }
            catch (Exception ex)  
            {
                return new JsonResult("Ingrese la fecha en el formato dd-mm.") { StatusCode = 400 };
            }
        }






        [HttpPost("v1/Funcion")]
        public async Task<IActionResult> AddFuncion(FuncionIdDTO funcion)
        {
            Funcion fun = new Funcion
            {
                Fecha = DateTime.Parse(funcion.Fecha),
                Horario = TimeSpan.Parse(funcion.Horario),
                SalaId = funcion.SalaId,
                PeliculaId = funcion.PeliculaId
            };
            bool resultado = await _serviceFunciones.AddFuncion(fun);
            if (resultado)
            {
                return Ok("Se agrego correctamente la funcion.");
            }
            else
            {
                return BadRequest("No se pudo agregar correctamente la funcion.");
            }
        }




        [HttpGet("v1/Funcion/{id}")]
        public async Task<IActionResult> getFuncionByID(int funcionID) 
        {
            FuncionDTO? funcionDTO = await _serviceFunciones.getFuncionByID(funcionID);
            if (funcionDTO == null) 
            {
                return NotFound("Funcion no encontrada.");
            }
            else 
            {
                return new JsonResult(funcionDTO) { StatusCode = 200 };
            }
        }




        [HttpDelete("v1/Funcion/{id}")]
        public async Task<IActionResult> removeFuncion(int funcionID)
        {
            int? resultado = await _serviceFunciones.removeFuncion(funcionID);
            if (resultado == null)
            {
                return BadRequest("No se encontre la funcion a eliminar.");
            }
            else
            {
                if (resultado == 0) 
                {
                    return Ok("Se elimino la funcion correctamente.");
                }
                else 
                {
                    return BadRequest("No se pudo eliminar la funcion debido a que tiene tickets vendidos.");
                }
            }
        }





        [HttpGet("/api/v1/Funcion/{id}/tickets")]
        public async Task<IActionResult> getCantTicketsDisponibles (int funcionID) 
        {
            int? resultado = await _serviceFunciones.getCantTicketsDisponibles(funcionID);
            if (resultado == null)
            {
                return NotFound("No existe la funcion solicitada.");
            }
            string res = "hay " + resultado + " tickets disponibles para la funcion " + funcionID;
            return new JsonResult(res) {StatusCode = 200};
        }



        

        [HttpPost("/api/v1/Funcion/{id}/tickets")]
        public async Task<IActionResult> AddTicket(string usuario, int funcionID)
        {
            bool resultado = await _serviceTickets.AddTicket(usuario, funcionID);
            if (resultado)
            {
                return Ok("Ticket obtenido exitosamente");
            }
            return BadRequest("Ha habido un problema");
        }

    }
}
