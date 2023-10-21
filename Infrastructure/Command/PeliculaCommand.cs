using Application.Interface.Peliculas;
using Application.Model.Response;
using Domain.Entity;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Command
{
    public class PeliculaCommand : IPeliculaCommand
    {
        private readonly CineContext _context;

        public PeliculaCommand(CineContext context)
        {
            _context = context;
        }

        public async Task<PeliculaResponseLong> updatePelicula(Pelicula pelicula)
        {
            Pelicula? aux = _context.Peliculas.FirstOrDefault(s => s.PeliculaId != pelicula.PeliculaId && s.Titulo == pelicula.Titulo);
            if (aux == null)
            {
                Pelicula peli = await _context.Peliculas.FindAsync(pelicula.PeliculaId);
                if (peli != null)
                {
                    peli.Titulo = pelicula.Titulo;
                    peli.Sinopsis = pelicula.Sinopsis;
                    peli.Poster = pelicula.Poster;
                    peli.Trailer = pelicula.Trailer;
                    peli.Genero = pelicula.Genero;
                    _context.Peliculas.Update(peli);
                    await _context.SaveChangesAsync();

                    peli = await _context.Peliculas
                                   .Include(f => f.Generos)
                                   .Include(s => s.Funciones)
                                   .FirstOrDefaultAsync(s => s.PeliculaId == pelicula.PeliculaId);

                    PeliculaResponseLong peliculaResponse = new PeliculaResponseLong
                    {
                        peliculaId = pelicula.PeliculaId,
                        titulo = peli.Titulo,
                        sinopsis = peli.Sinopsis,
                        poster = peli.Poster,
                        trailer = peli.Trailer,
                        genero = new GeneroResponse
                        {
                            id = peli.Generos.GeneroId,
                            nombre = peli.Generos.Nombre
                        },
                        funciones = new List<FuncionResponseShort>()
                    };
                    FuncionResponseShort funcionShort;
                    foreach (Funcion funcion in peli.Funciones)
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
            else
            {
                throw new AggregateException();
            }
        }

    }
}
