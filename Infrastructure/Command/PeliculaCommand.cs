using Application.Interface.Peliculas;
using Application.Model;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Command
{
    public class PeliculaCommand : IPeliculaCommand
    {
        private readonly CineContext _context;

        public PeliculaCommand(CineContext context)
        {
            _context = context;
        }

        public async Task<bool> updatePelicula(Pelicula pelicula) 
        {
            Pelicula peli = await _context.Peliculas.FindAsync(pelicula.PeliculaId);
            if (peli != null)
            {
                peli.Titulo = pelicula.Titulo;
                peli.Sinopsis = pelicula.Sinopsis;
                peli.Poster = pelicula.Poster;
                peli.Trailer = pelicula.Trailer;
                peli.GeneroId = pelicula.GeneroId;
                _context.Peliculas.Update(peli);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
