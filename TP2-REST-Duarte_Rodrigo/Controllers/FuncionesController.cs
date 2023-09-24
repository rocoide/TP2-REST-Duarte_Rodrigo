using Application.Interface.Funciones;
using Application.Model;
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
        private readonly IFuncionService _service;

        public FuncionesController(IFuncionService service)
        {
            _service = service;
        }




        [HttpGet("funciones")]
        public async Task<IActionResult> getFunciones(string titulo = null, string fecha = null, int? generoID = null)
        {
            List<FuncionDTO> lista = null;
            //sin filtro, devuelve todas las funciones
            if ((titulo == null) && (fecha == null) && (generoID == null))
            {
                lista = await _service.getAllFunciones();
                return new JsonResult(lista);
            }
            //caso sin filtros funciona bien
            List<FuncionDTO> listaFinal = null;
            if (titulo != null)
            {
                lista = await _service.getFuncionesByTitulo(titulo);
                listaFinal = lista;
            }
            if (fecha != null)
            {
                DateTime fech = DateTime.Parse(fecha);
                lista = await _service.getFuncionesByFecha(fech);
                if (listaFinal != null)
                {
                    listaFinal = await _service.compararDTO(listaFinal, lista);
                }
                else
                {
                    listaFinal = lista;
                }
            }
            if (generoID != null)
            {
                lista = await _service.getFuncionesByGenero(generoID);
                if (listaFinal != null)
                {
                    listaFinal = await _service.compararDTO(listaFinal, lista);
                }
                else
                {
                    listaFinal = lista;
                }
            }
            return new JsonResult(listaFinal);
        }




        [HttpPost("funcion")]
        public async Task<IActionResult> AddFuncion(FuncionIdDTO funcion)
        {
            Funcion fun = new Funcion
            {
                Fecha = DateTime.Parse(funcion.Fecha),
                Horario = TimeSpan.Parse(funcion.Horario),
                SalaId = funcion.SalaId,
                PeliculaId = funcion.PeliculaId
            };
            bool resultado = await _service.AddFuncion(fun);
            if (resultado)
            {
                return Ok("Se agrego correctamente la funcion.");
            }
            else
            {
                return BadRequest("No se pudo agregar correctamente la funcion.");
            }
        }




        [HttpDelete("funcion")]
        public async Task<IActionResult> removeFuncion(int funcionID)
        {
            bool resultado = await _service.removeFuncion(funcionID);
            if (resultado)
            {
                return Ok("Se elimino correctamente la funcion.");
            }
            else
            {
                return BadRequest("No se encontre el ID a eliminar.");
            }
        }

        [HttpGet("ticketsParaFuncion/{funcionID}")]
        public async Task<IActionResult> getCantTicketsDisponibles (int funcionID) 
        {
            int? resultado = await _service.getCantTicketsDisponibles(funcionID);
            if (resultado == null)
            {
                return NotFound("No existe la funcion solicitada.");
            }
            string res = "hay " + resultado + "tickets disponibles para la funcion " + funcionID;
            return new JsonResult(res) {StatusCode = 200};
        }

        

    }
}
