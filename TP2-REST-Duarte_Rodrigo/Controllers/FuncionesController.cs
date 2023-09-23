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
            //sin filtro, devuelve todas las funciones
            if ((titulo == null) && (fecha == null) && (generoID == null))
            {
                List<FuncionDTO> lista = await _service.getAllFunciones();
                return new JsonResult(lista);
            }
            List<FuncionDTO> lista1 = null;
            List<FuncionDTO> lista2 = null;
            List<FuncionDTO> lista3 = null;
            List<FuncionDTO> listaFinal = null;
            if (titulo != null) 
            {
                lista1 = await _service.getFuncionesByTitulo(titulo);
            }
            if (fecha != null) 
            {
                DateTime fech = DateTime.Parse(fecha);
                lista2 = await _service.getFuncionesByFecha(fech);
                if (lista1 != null) 
                {
                    listaFinal = lista1.Intersect(lista2).ToList();
                }
            }
            if (generoID != null) 
            {
                lista3 = await _service.getFuncionesByGenero(generoID);
                if (listaFinal != null) 
                {
                    listaFinal = listaFinal.Intersect(lista3).ToList();
                }
            }
            return new JsonResult(listaFinal);
        }

        
        [HttpPost("funcion")]
        public async Task<IActionResult> getFunciones(FuncionIdDTO funcion) 
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
    }
}
