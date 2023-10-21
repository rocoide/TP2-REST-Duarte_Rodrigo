using Application.Interface.Funciones;
using Application.Model.Response;
using Domain.Entity;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class FuncionQuery : IFuncionQuery
    {
        private readonly CineContext _context;

        public FuncionQuery(CineContext context)
        {
            _context = context;
        }

        public async Task<List<FuncionResponse>> getAllFunciones()
        {
            List<FuncionResponse> funciones = await _context.Funciones
                                                       .Include(s => s.Salas)
                                                       .Include(f => f.Peliculas)
                                                           .ThenInclude(m => m.Generos)
                                                       .Select(s => new FuncionResponse
                                                       {
                                                           funcionId = s.FuncionId,
                                                           pelicula = new PeliculaResponseShort
                                                           {
                                                               peliculaId = s.Peliculas.PeliculaId,
                                                               titulo = s.Peliculas.Titulo,
                                                               poster = s.Peliculas.Poster,
                                                               genero = new GeneroResponse
                                                               {
                                                                   id = s.Peliculas.Genero,
                                                                   nombre = s.Peliculas.Generos.Nombre
                                                               }

                                                           },
                                                           sala = new SalaResponse
                                                           {
                                                               id = s.SalaId,
                                                               nombre = s.Salas.Nombre,
                                                               capacidad = s.Salas.Capacidad
                                                           },
                                                           fecha = s.Fecha,
                                                           horario = s.Horario.ToString(@"hh\:mm")
                                                       })
                                                       .ToListAsync();
            return funciones;
        }

        public async Task<List<FuncionResponse>> getFuncionesByTitulo(string titu)
        {
            List<FuncionResponse> funciones = await _context.Funciones
                                                       .Include(s => s.Salas)
                                                       .Include(f => f.Peliculas)
                                                           .ThenInclude(m => m.Generos)
                                                       .Where(f => f.Peliculas.Titulo.Contains(titu))
                                                       .Select(s => new FuncionResponse
                                                       {
                                                           funcionId = s.FuncionId,
                                                           pelicula = new PeliculaResponseShort
                                                           {
                                                               peliculaId = s.Peliculas.PeliculaId,
                                                               titulo = s.Peliculas.Titulo,
                                                               poster = s.Peliculas.Poster,
                                                               genero = new GeneroResponse
                                                               {
                                                                   id = s.Peliculas.Genero,
                                                                   nombre = s.Peliculas.Generos.Nombre
                                                               }

                                                           },
                                                           sala = new SalaResponse
                                                           {
                                                               id = s.SalaId,
                                                               nombre = s.Salas.Nombre,
                                                               capacidad = s.Salas.Capacidad
                                                           },
                                                           fecha = s.Fecha,
                                                           horario = s.Horario.ToString(@"hh\:mm")
                                                       })
                                                       .ToListAsync();
            return funciones;
        }

        public async Task<List<FuncionResponse>> getFuncionesByFecha(DateTime fecha)
        {
            List<FuncionResponse> funciones = await _context.Funciones
                                                       .Include(s => s.Salas)
                                                       .Include(f => f.Peliculas)
                                                           .ThenInclude(m => m.Generos)
                                                       .Where(f => (f.Fecha.Day == fecha.Day) && (f.Fecha.Month == fecha.Month))
                                                       .Select(s => new FuncionResponse
                                                       {
                                                           funcionId = s.FuncionId,
                                                           pelicula = new PeliculaResponseShort
                                                           {
                                                               peliculaId = s.Peliculas.PeliculaId,
                                                               titulo = s.Peliculas.Titulo,
                                                               poster = s.Peliculas.Poster,
                                                               genero = new GeneroResponse
                                                               {
                                                                   id = s.Peliculas.Genero,
                                                                   nombre = s.Peliculas.Generos.Nombre
                                                               }

                                                           },
                                                           sala = new SalaResponse
                                                           {
                                                               id = s.SalaId,
                                                               nombre = s.Salas.Nombre,
                                                               capacidad = s.Salas.Capacidad
                                                           },
                                                           fecha = s.Fecha,
                                                           horario = s.Horario.ToString(@"hh\:mm")
                                                       })
                                                       .ToListAsync();
            return funciones;
        }

        public async Task<List<FuncionResponse>> getFuncionesByGenero(int? generoID)
        {
            List<FuncionResponse> funciones = await _context.Funciones
                                                       .Include(s => s.Salas)
                                                       .Include(f => f.Peliculas)
                                                           .ThenInclude(m => m.Generos)
                                                       .Where(f => f.Peliculas.Genero == generoID)
                                                       .Select(s => new FuncionResponse
                                                       {
                                                           funcionId = s.FuncionId,
                                                           pelicula = new PeliculaResponseShort
                                                           {
                                                               peliculaId = s.Peliculas.PeliculaId,
                                                               titulo = s.Peliculas.Titulo,
                                                               poster = s.Peliculas.Poster,
                                                               genero = new GeneroResponse
                                                               {
                                                                   id = s.Peliculas.Genero,
                                                                   nombre = s.Peliculas.Generos.Nombre
                                                               }

                                                           },
                                                           sala = new SalaResponse
                                                           {
                                                               id = s.SalaId,
                                                               nombre = s.Salas.Nombre,
                                                               capacidad = s.Salas.Capacidad
                                                           },
                                                           fecha = s.Fecha,
                                                           horario = s.Horario.ToString(@"hh\:mm")
                                                       })
                                                       .ToListAsync();
            return funciones;
        }


        public async Task<FuncionResponse> getFuncionByID(int funcionID)
        {
            Funcion? funcion = await _context.Funciones
                                            .Include(m => m.Salas)
                                            .Include(t => t.Tickets)
                                            .Include(f => f.Peliculas)
                                                .ThenInclude(m => m.Generos)
                                            .FirstOrDefaultAsync(s => s.FuncionId == funcionID);
            if (funcion != null)
            {
                FuncionResponse funcionResponse = new FuncionResponse
                {
                    funcionId = funcion.FuncionId,
                    pelicula = new PeliculaResponseShort
                    {
                        peliculaId = funcion.Peliculas.PeliculaId,
                        titulo = funcion.Peliculas.Titulo,
                        poster = funcion.Peliculas.Poster,
                        genero = new GeneroResponse
                        {
                            id = funcion.Peliculas.Genero,
                            nombre = funcion.Peliculas.Generos.Nombre
                        }

                    },
                    sala = new SalaResponse
                    {
                        id = funcion.SalaId,
                        nombre = funcion.Salas.Nombre,
                        capacidad = funcion.Salas.Capacidad
                    },
                    fecha = funcion.Fecha,
                    horario = funcion.Horario.ToString(@"hh\:mm")
                };
                return funcionResponse;
            }
            return null;
        }
    }
}
