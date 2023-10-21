using Application.Model.Response;
using Domain.Entity;

namespace Application.Interface.Peliculas
{
    public interface IPeliculaCommand
    {
        Task<PeliculaResponseLong> updatePelicula(Pelicula pelicula);
    }
}
