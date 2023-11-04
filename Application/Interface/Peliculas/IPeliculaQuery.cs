using Domain.Entity;

namespace Application.Interface.Peliculas
{
    public interface IPeliculaQuery
    {
        Task<Pelicula?> GetPeliculaById(int PeliculaId);
    }
}
