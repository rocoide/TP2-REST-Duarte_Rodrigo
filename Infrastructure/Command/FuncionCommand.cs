using Application.Interface.Funciones;
using Domain.Entity;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Command
{
    public class FuncionCommand : IFuncionCommand
    {
        private readonly CineContext Context;

        public FuncionCommand(CineContext Context)
        {
            this.Context = Context;
        }
        public async Task<Funcion?> AddFuncion(Funcion Fun)
        {
            TimeSpan TiempoAgregado = new TimeSpan(2, 30, 0);
            TimeSpan Aux = Fun.Horario + TimeSpan.FromHours(-2) + TimeSpan.FromMinutes(-30); //auxiliar para simular la comparacion con el fin de las peliculas en cartelera
            TimeSpan HoraFin = Fun.Horario.Add(TiempoAgregado);
            Funcion? FuncionSolapada = await Context.Funciones
                                                    .Include(s => s.Peliculas)
                                                        .ThenInclude(m => m.Generos)
                                                    .Include(s => s.Salas)
                                                    .FirstOrDefaultAsync(f => (f.SalaId == Fun.SalaId) &&
                                                                              (f.Fecha.Month == Fun.Fecha.Month) &&
                                                                              (f.Fecha.Day == Fun.Fecha.Day) &&
                                                                              (
                                                                                 (f.Horario >= Fun.Horario && f.Horario < HoraFin) ||
                                                                                 (f.Horario <= Fun.Horario && f.Horario > Aux)
                                                                              )
                                                                        );
            if (FuncionSolapada == null)
            {
                Context.Funciones.Add(Fun);
                await Context.SaveChangesAsync();
                Funcion? Fun2 = await Context.Funciones
                                             .Include(s => s.Peliculas)
                                                .ThenInclude(m => m.Generos)
                                             .Include(s => s.Salas)
                                             .FirstOrDefaultAsync(f => f.FuncionId == Fun.FuncionId);
                return Fun2;
            }
            else
            {
                return null;
            }
        }

        public async Task<Funcion?> RemoveFuncion(int FuncionId)
        {
            List<Ticket> ListaTickets = await Context.Tickets.Where(s => s.FuncionId == FuncionId)
                                                             .ToListAsync();
            if (ListaTickets.Count == 0)
            {
                Funcion Funcion = await Context.Funciones.FindAsync(FuncionId);
                Context.Funciones.Remove(Funcion);
                await Context.SaveChangesAsync();
                return Funcion;
            }
            else
            {
                return null;
            }
        }
    }
}
