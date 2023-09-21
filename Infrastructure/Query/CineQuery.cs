using Application.Interface;
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
    public class CineQuery : ICineQuery
    {
        private readonly CineContext _context;

        public CineQuery(CineContext context) 
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
    }
}
