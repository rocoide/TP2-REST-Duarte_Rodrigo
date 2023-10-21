using Application.Interface.Peliculas;
using Application.Model.DTO;
using Application.Model.Response;
using Domain.Entity;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

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

        public async Task<PeliculaResponseLong> getPelicula(int id)
        {
            Pelicula? pelicula = _context.Peliculas
                                        .Include(f => f.Generos)
                                        .Include(s => s.Funciones)
                                        .FirstOrDefault(s => s.PeliculaId == id);
            if (pelicula != null)
            {
                PeliculaResponseLong peliculaResponse = new PeliculaResponseLong
                {
                    peliculaId = id,
                    titulo = pelicula.Titulo,
                    sinopsis = pelicula.Sinopsis,
                    poster = pelicula.Poster,
                    trailer = pelicula.Trailer,
                    genero = new GeneroResponse
                    {
                        id = pelicula.Generos.GeneroId,
                        nombre = pelicula.Generos.Nombre
                    },
                    funciones = new List<FuncionResponseShort>()
                };
                FuncionResponseShort funcionShort;
                foreach (Funcion funcion in pelicula.Funciones)
                {
                    funcionShort = new FuncionResponseShort
                    {
                        funcionId = funcion.FuncionId,
                        fecha = funcion.Fecha,
                        horario = funcion.Horario.ToString(@"hh\:mm")
                    };
                    peliculaResponse.funciones.Add(funcionShort);
                }
                return peliculaResponse;
            }
            else
            {
                return null;
            }
        }
    }
}
