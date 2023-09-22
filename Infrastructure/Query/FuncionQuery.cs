using Application.Interface.Funciones;
using Application.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                                                                           Fecha = s.Fecha.ToString(),
                                                                           Horario = s.Horario.ToString(),
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
                                                                       .Where(f => f.Peliculas.Titulo == titu)
                                                                       .Select(s => new FuncionDTO
                                                                       {
                                                                           Fecha = s.Fecha.ToString(),
                                                                           Horario = s.Horario.ToString(),
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
                                                                           Fecha = s.Fecha.ToString(),
                                                                           Horario = s.Horario.ToString(),
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
                                                                           Fecha = s.Fecha.ToString(),
                                                                           Horario = s.Horario.ToString(),
                                                                           PeliculaNombre = s.Peliculas.Titulo,
                                                                           PeliculaGenero = s.Peliculas.Generos.Nombre,
                                                                           SalaNombre = s.Salas.Nombre
                                                                       })
                                                                       .ToListAsync();
            return funciones;
        }
    }
}
