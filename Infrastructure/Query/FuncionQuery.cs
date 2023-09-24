using Application.Interface.Funciones;
using Application.Model;
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

        public async Task<List<FuncionDTO>> getAllFunciones() 
        {
            List<FuncionDTO> funciones = await _context.Funciones
                                                       .Include(s => s.Salas)
                                                       .Include(f => f.Peliculas)
                                                           .ThenInclude(m => m.Generos)
                                                       .Select(s => new FuncionDTO
                                                       {
                                                           Fecha = s.Fecha.ToString("dd/MM/yyyy"),
                                                           Horario = s.Horario.ToString(@"hh\:mm"),
                                                           Dia = s.Fecha.ToString("dddd"),
                                                           PeliculaNombre = s.Peliculas.Titulo,
                                                           PeliculaGenero = s.Peliculas.Generos.Nombre,
                                                           SalaNombre = s.Salas.Nombre
                                                       })
                                                       .ToListAsync();
            return funciones;
        }

        public async Task<List<FuncionDTO>> getFuncionesByTitulo(string titu) 
        {
            List<FuncionDTO> funciones = await _context.Funciones
                                                       .Include(s => s.Salas)
                                                       .Include(f => f.Peliculas)
                                                           .ThenInclude(m => m.Generos)
                                                       .Where(f => f.Peliculas.Titulo.Contains(titu))
                                                       .Select(s => new FuncionDTO
                                                       {
                                                           Fecha = s.Fecha.ToString("dd/MM/yyyy"),
                                                           Horario = s.Horario.ToString(@"hh\:mm"),
                                                           Dia = s.Fecha.ToString("dddd"),
                                                           PeliculaNombre = s.Peliculas.Titulo,
                                                           PeliculaGenero = s.Peliculas.Generos.Nombre,
                                                           SalaNombre = s.Salas.Nombre
                                                       })
                                                       .ToListAsync();
            return funciones;
        }

        public async Task<List<FuncionDTO>> getFuncionesByFecha(DateTime fecha) 
        {
            List<FuncionDTO> funciones = await _context.Funciones
                                                       .Include(s => s.Salas)
                                                       .Include(f => f.Peliculas)
                                                           .ThenInclude(m => m.Generos)
                                                       .Where(f => (f.Fecha.Day == fecha.Day) && (f.Fecha.Month == fecha.Month))
                                                       .Select(s => new FuncionDTO
                                                       {
                                                           Fecha = s.Fecha.ToString("dd/MM/yyyy"),
                                                           Horario = s.Horario.ToString(@"hh\:mm"),
                                                           Dia = s.Fecha.ToString("dddd"),
                                                           PeliculaNombre = s.Peliculas.Titulo,
                                                           PeliculaGenero = s.Peliculas.Generos.Nombre,
                                                           SalaNombre = s.Salas.Nombre
                                                       })
                                                       .ToListAsync();
            return funciones;
        }

        public async Task<List<FuncionDTO>> getFuncionesByGenero(int? generoID) 
        {
            List<FuncionDTO> funciones = await _context.Funciones
                                                       .Include(s => s.Salas)
                                                       .Include(f => f.Peliculas)
                                                           .ThenInclude(m => m.Generos)
                                                       .Where(f => f.Peliculas.GeneroId == generoID)
                                                       .Select(s => new FuncionDTO
                                                       {
                                                           Fecha = s.Fecha.ToString("dd/MM/yyyy"),
                                                           Horario = s.Horario.ToString(@"hh\:mm"),
                                                           Dia = s.Fecha.ToString("dddd"),
                                                           PeliculaNombre = s.Peliculas.Titulo,
                                                           PeliculaGenero = s.Peliculas.Generos.Nombre,
                                                           SalaNombre = s.Salas.Nombre
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
