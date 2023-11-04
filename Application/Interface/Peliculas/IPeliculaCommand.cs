using Application.Model.DTO;
using Domain.Entity;

namespace Application.Interface.Peliculas
{
    public interface IPeliculaCommand
    {
        Task<Pelicula?> UpdatePelicula(PeliculaDTO PeliculaDTO, int PeliculaId);
    }
}
