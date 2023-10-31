using Application.Model.DTO;
using Application.Model.Response;
using Domain.Entity;

namespace Application.Interface.Peliculas
{
    public interface IPeliculaQuery
    {
        Task<List<Pelicula>> GetPeliculas();
        Task<Pelicula> GetPeliculaById(int PeliculaId);
    }
}
