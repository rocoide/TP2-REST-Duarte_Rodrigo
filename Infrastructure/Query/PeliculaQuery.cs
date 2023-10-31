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

        public async Task<List<Pelicula>> GetPeliculas()
        {
            List<Pelicula> peliculas = _context.Peliculas
                                                  .Include(f => f.Generos)
                                                  .ToList();
            return peliculas;
        }

        public async Task<Pelicula> GetPeliculaById(int id)
        {
            Pelicula? Pelicula = _context.Peliculas
                                        .Include(f => f.Generos)
                                        .Include(s => s.Funciones)
                                        .FirstOrDefault(s => s.PeliculaId == id);
            if (Pelicula != null)
            {
                //PeliculaResponseLong peliculaResponse = new PeliculaResponseLong
                //{
                //    peliculaId = id,
                //    titulo = pelicula.Titulo,
                //    sinopsis = pelicula.Sinopsis,
                //    poster = pelicula.Poster,
                //    trailer = pelicula.Trailer,
                //    genero = new GeneroResponse
                //    {
                //        Id = pelicula.Generos.GeneroId,
                //        Nombre = pelicula.Generos.Nombre
                //    },
                //    funciones = new List<FuncionResponseShort>()
                //};
                //FuncionResponseShort funcionShort;
                //foreach (Funcion funcion in pelicula.Funciones)
                //{
                //    funcionShort = new FuncionResponseShort
                //    {
                //        funcionId = funcion.FuncionId,
                //        fecha = funcion.Fecha,
                //        horario = funcion.Horario.ToString(@"hh\:mm")
                //    };
                //    peliculaResponse.funciones.Add(funcionShort);
                //}
                return Pelicula;
            }
            else
            {
                return null;
            }
        }
    }
}
