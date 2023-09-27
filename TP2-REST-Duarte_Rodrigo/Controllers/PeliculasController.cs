using Application.Interface.Peliculas;
using Application.Model.DTO;
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




        [HttpGet("/api/v1/Pelicula/{id}")]
        public async Task<IActionResult> getPelicula(int id) 
        {
            PeliculaDTO result = await _service.getPelicula(id);
            return new JsonResult(result);
        }






        [HttpPut("/api/v1/Pelicula/{id}")]
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
