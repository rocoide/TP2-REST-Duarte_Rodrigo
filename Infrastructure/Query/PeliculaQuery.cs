using Application.Interface.Pelicula;
using Application.Model;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Query
{
    public class PeliculaQuery : IPeliculaQuery
    {
        private readonly CineContext _context;

        public PeliculaQuery(CineContext context) 
        {
            _context = context;
        }

        public async Task<List<PeliculaDTO>> getPeliculas()
        {
            List<PeliculaDTO> peliculas = _context.Peliculas
                                                                                .Include(f => f.Generos)
                                                                                .Select(s => new PeliculaDTO 
                                                                                {
                                                                                    Titulo = s.Titulo,
                                                                                    Sinopsis = s.Sinopsis,
                                                                                    Poster = s.Poster,
                                                                                    Trailer = s.Trailer,
                                                                                    Genero = s.Generos.Nombre
                                                                                })
                                                                                .ToList();
            return peliculas;
        }

        public async Task<PeliculaDTO> getPelicula(int id) 
        {
            Pelicula? pelicula = _context.Peliculas
                                                           .Include(f => f.Generos)
                                                           .FirstOrDefault(s => s.PeliculaId == id);
            PeliculaDTO peliculaDTO = new PeliculaDTO{
                                                                Titulo = pelicula.Titulo,
                                                                Sinopsis = pelicula.Sinopsis,
                                                                Poster = pelicula.Poster,
                                                                Trailer = pelicula.Trailer,
                                                                Genero = pelicula.Generos.Nombre
                                                                            };
            return peliculaDTO;
        }
    }
}
