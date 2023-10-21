using Application.Model.DTO;
using Application.Model.Response;

namespace Application.Interface.Peliculas
{
    public interface IPeliculaQuery
    {
        Task<List<PeliculaDTO>> getPeliculas();
        Task<PeliculaResponseLong> getPelicula(int id);
    }
}
