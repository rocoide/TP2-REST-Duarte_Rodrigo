using Application.Interface.Peliculas;
using Application.Model;
using Domain.Entity;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TP2_REST_Duarte_Rodrigo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly IPeliculaService _service;

        public PeliculasController(IPeliculaService service) 
        {
            _service = service;
        }

        [HttpGet("Peliculas")]
        public async Task<IActionResult> getPeliculas() 
        {
            List<PeliculaDTO> result = await _service.getPeliculas();
            return new JsonResult(result);
        }

        [HttpGet("Pelicula/{id}")]
        public async Task<IActionResult> getPelicula(int id) 
        {
            PeliculaDTO result = await _service.getPelicula(id);
            return new JsonResult(result);
        }

        [HttpPut("Pelicula")]
        public async Task<IActionResult> updatePelicula(PeliculaIdDTO peliculaIdDTO)
        {
            bool resultado = await _service.updatePelicula(peliculaIdDTO);
            if (resultado) 
            {
                return new JsonResult("Se ha actualizado la pelicula correctamente") {StatusCode = 201};
            }
            return NotFound("No se ha encontrado la pelicula");
        }
    }
}
