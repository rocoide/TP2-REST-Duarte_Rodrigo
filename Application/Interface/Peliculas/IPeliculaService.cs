using Application.Model.DTO;
using Application.Model.Response.Peliculas;

namespace Application.Interface.Peliculas
{
    public interface IPeliculaService
    {
        Task<PeliculaResponse> GetPeliculaById(int PeliculaId);
        Task<PeliculaResponse> UpdatePelicula(PeliculaDTO PeliculaDTO, int PeliculaId);
    }
}
