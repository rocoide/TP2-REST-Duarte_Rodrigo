using Application.Interface;
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
        private readonly ICineService _service;

        public PeliculasController(ICineService service) 
        {
            _service = service;
        }

        [HttpGet("Peliculas")]
        public async Task<IActionResult> getPeliculas() 
        {
            List<PeliculaDTO> result = await _service.getPeliculas();
            return new JsonResult(result);
        }
    }
}
