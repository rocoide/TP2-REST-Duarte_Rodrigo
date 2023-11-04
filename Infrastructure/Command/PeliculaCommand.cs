using Application.Interface.Peliculas;
using Application.Model.DTO;
using Domain.Entity;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Command
{
    public class PeliculaCommand : IPeliculaCommand
    {
        private readonly CineContext Context;

        public PeliculaCommand(CineContext Context)
        {
            this.Context = Context;
        }

        public async Task<Pelicula?> UpdatePelicula(PeliculaDTO PeliculaDTO, int PeliculaId)
        {
            Pelicula? Pelicula = await Context.Peliculas.Include(s => s.Funciones)
                                                        .Include(m => m.Generos)
                                                        .FirstOrDefaultAsync(s => s.PeliculaId != PeliculaId && s.Titulo == PeliculaDTO.Titulo);
            if (Pelicula == null)
            {
                Pelicula = await Context.Peliculas.Include(s => s.Funciones)
                                                  .Include(m => m.Generos)
                                                  .FirstOrDefaultAsync(s => s.PeliculaId == PeliculaId);
                Pelicula.Titulo = PeliculaDTO.Titulo;
                Pelicula.Poster = PeliculaDTO.Poster;
                Pelicula.Trailer = PeliculaDTO.Trailer;
                Pelicula.Sinopsis = PeliculaDTO.Sinopsis;
                Pelicula.Genero = PeliculaDTO.Genero;
                await Context.SaveChangesAsync();
                return Pelicula;
            }
            else
            {
                return null;
            }
        }
    }
}
