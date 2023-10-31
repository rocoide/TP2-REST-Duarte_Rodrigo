using Application.Interface.Peliculas;
using Application.Model.DTO;
using Application.Model.Response;
using Microsoft.AspNetCore.Mvc;

namespace TP2_REST_Duarte_Rodrigo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly IPeliculaService Service;

        public PeliculasController(IPeliculaService service)
        {
            Service = service;
        }




        [HttpGet("/api/v1/Pelicula/{id}")]
        public async Task<IActionResult> getPelicula(int id)
        {
            try
            {
                PeliculaResponseLong Result = await Service.GetPeliculaById(id);
                if (Result == null)
                {
                    return new JsonResult("No se encontro la pelicula solicitada") { StatusCode = 404 };
                }
                else
                {
                    return new JsonResult(Result) { StatusCode = 200 };
                }
            }
            catch (Exception)
            {
                return new JsonResult("Por favor ingrese un valor valido.") { StatusCode = 400 };
            }
        }






        [HttpPut("/api/v1/Pelicula/{id}")]
        public async Task<IActionResult> updatePelicula(PeliculaIdDTO peliculaIdDTO, int id)
        {
            try
            {
                bool cumple = await Service.validarCampos(peliculaIdDTO);
                if (cumple)
                {
                    PeliculaResponseLong resultado = await Service.updatePelicula(peliculaIdDTO, id);
                    if (resultado != null)
                    {
                        return new JsonResult(resultado) { StatusCode = 201 };
                    }
                    return NotFound("No se ha encontrado la pelicula");
                }
                else
                {
                    return new JsonResult("Asegurese de que los campos cumplan con las especificaciones.") { StatusCode = 400 };
                }
            }
            catch (AggregateException)
            {
                return new JsonResult("No se ha podido actualizar la pelicula debido a que existe otra con el mismo titulo.") { StatusCode = 409 };
            }
            catch (Exception)
            {
                return new JsonResult("Por favor ingrese un ID de genero entre los valores 1-20.");
            }
        }

    }
}
