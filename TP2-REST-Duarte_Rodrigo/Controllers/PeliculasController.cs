using Application.Excepcions;
using Application.Interface.Peliculas;
using Application.Model.DTO;
using Application.Model.Response.Peliculas;
using Application.Validation;
using Microsoft.AspNetCore.Mvc;

namespace TP2_REST_Duarte_Rodrigo.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly IPeliculaService PeliculaService;

        public PeliculasController(IPeliculaService PeliculaService)
        {
            this.PeliculaService = PeliculaService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetPelicula(int id)
        {
            try
            {
                PeliculaResponse Result = await PeliculaService.GetPeliculaById(id);
                return Ok(Result);
            }
            catch (FormatException Ex)
            {
                var ObjetoAnonimo = new
                {
                    Message = Ex.Message
                };
                return BadRequest(ObjetoAnonimo);
            }
            catch (NotFoundExcepcion Ex)
            {
                var ObjetoAnonimo = new
                {
                    Message = Ex.Message
                };
                return NotFound(ObjetoAnonimo);
            }
        }




        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePelicula(PeliculaDTO PeliculaDTO, int id)
        {
            try
            {
                ValidarCamposPelicula.Validar(PeliculaDTO);
                PeliculaResponse PeliculaResponse = await PeliculaService.UpdatePelicula(PeliculaDTO, id);
                return Ok(PeliculaResponse);
            }
            catch (FormatException Ex)
            {
                var ObjetoAnonimo = new
                {
                    Message = Ex.Message
                };
                return BadRequest(ObjetoAnonimo);
            }
            catch (NotFoundExcepcion Ex)
            {
                var ObjetoAnonimo = new
                {
                    Message = Ex.Message
                };
                return NotFound(ObjetoAnonimo);
            }
            catch (ConflicExcepcion Ex)
            {
                var ObjetoAnonimo = new
                {
                    Message = Ex.Message
                };
                return Conflict(ObjetoAnonimo);
            }
        }

    }
}
