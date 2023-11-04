using Application.Interface.Funciones;
using Domain.Entity;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class FuncionQuery : IFuncionQuery
    {
        private readonly CineContext Context;

        public FuncionQuery(CineContext Context)
        {
            this.Context = Context;
        }

        public async Task<List<Funcion>> GetFunciones(string? Titulo, string? Fecha, int? GeneroId)
        {
            List<Funcion> ListaFuncion = await Context.Funciones
                                                      .Include(m => m.Peliculas)
                                                        .ThenInclude(f => f.Generos)
                                                      .Include(m => m.Salas)
                                                      .Where(s => (Titulo != null ? (s.Peliculas.Titulo == Titulo) : true) &&
                                                                  (Fecha != null ? (s.Fecha.Year == DateTime.Parse(Fecha).Year &&
                                                                                    s.Fecha.Month == DateTime.Parse(Fecha).Month &&
                                                                                    s.Fecha.Day == DateTime.Parse(Fecha).Day
                                                                                   ) : true) &&
                                                                  (GeneroId != null ? (s.Peliculas.Genero == GeneroId) : true)
                                                            ).ToListAsync();
            return ListaFuncion;
        }


        public async Task<Funcion?> GetFuncionById(int FuncionId)
        {
            Funcion? Funcion = await Context.Funciones
                                            .Include(m => m.Salas)
                                            .Include(t => t.Tickets)
                                            .Include(f => f.Peliculas)
                                                .ThenInclude(m => m.Generos)
                                            .FirstOrDefaultAsync(s => s.FuncionId == FuncionId);
            return Funcion;
        }
    }
}
