using Application.Interface.Peliculas;
using Domain.Entity;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class PeliculaQuery : IPeliculaQuery
    {
        private readonly CineContext Context;

        public PeliculaQuery(CineContext Context)
        {
            this.Context = Context;
        }

        public async Task<Pelicula?> GetPeliculaById(int PeliculaId)
        {
            Pelicula? Pelicula = await Context.Peliculas
                                              .Include(f => f.Generos)
                                              .Include(s => s.Funciones)
                                              .FirstOrDefaultAsync(s => s.PeliculaId == PeliculaId);
            return Pelicula;
        }
    }
}
