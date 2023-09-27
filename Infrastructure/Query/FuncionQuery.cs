using Application.Interface.Funciones;
using Application.Model.DTO;
using Application.Model.Response;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                                                           pelicula = new PeliculaResponseShort {
                                                               peliculaId = s.Peliculas.PeliculaId,
                                                               titulo = s.Peliculas.Titulo,
                                                               poster = s.Peliculas.Poster,
                                                               genero = new GeneroResponse
                                                               {
                                                                   id = s.Peliculas.GeneroId,
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
                                                                   id = s.Peliculas.GeneroId,
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
                                                                   id = s.Peliculas.GeneroId,
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
                                                       .Where(f => f.Peliculas.GeneroId == generoID)
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
                                                                   id = s.Peliculas.GeneroId,
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

        public async Task<int?> getCantTicketsDisponibles(int funcionID) 
        {
            int resultado;
            Funcion funcion = _context.Funciones.Include(m => m.Salas).FirstOrDefault(s => s.FuncionId == funcionID);
            if (funcion == null)
            {
                return null;
            }
            else
            {
                List<Ticket> lista_tickets = _context.Tickets
                                                     .Where(s => s.FuncionId == funcionID)
                                                     .ToList();
                resultado = (funcion.Salas.Capacidad - lista_tickets.Count);
            }
            return resultado;
        }

        public async Task<FuncionDTO> getFuncionByID(int funcionID) 
        {
            Funcion? funcion = await _context.Funciones
                                            .Include(m => m.Salas)
                                            .Include(t => t.Tickets)
                                            .Include(f => f.Peliculas)
                                                .ThenInclude(m => m.Generos)
                                            .FirstOrDefaultAsync(s => s.FuncionId == funcionID);
            if (funcion != null) 
            {
                FuncionDTO funcionDTO = new FuncionDTO
                {
                    Fecha = funcion.Fecha.ToString("dd/MM/yyyy"),
                    Horario = funcion.Horario.ToString(@"hh\:mm"),
                    Dia = funcion.Fecha.ToString("dddd"),
                    SalaNombre = funcion.Salas.Nombre,
                    PeliculaNombre = funcion.Peliculas.Titulo,
                    PeliculaGenero = funcion.Peliculas.Generos.Nombre
                };
                return funcionDTO;
            }
            return null;
        }
    }
}
