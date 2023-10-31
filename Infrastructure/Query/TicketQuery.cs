using Application.Interface.Tickets;
using Domain.Entity;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class TicketQuery : ITicketQuery
    {
        private readonly CineContext Context;

        public TicketQuery(CineContext Context)
        {
            this.Context = Context;
        }

        public async Task<int?> GetCantTicketsDisponibles(int FuncionId)
        {
            int Resultado;
            Funcion? Funcion = await Context.Funciones.Include(m => m.Salas).FirstOrDefaultAsync(s => s.FuncionId == FuncionId);
            if (Funcion == null)
            {
                return null;
            }
            else
            {
                List<Ticket> ListaTickets = Context.Tickets
                                                    .Where(s => s.FuncionId == FuncionId)
                                                    .ToList();
                Resultado = (Funcion.Salas.Capacidad - ListaTickets.Count);
            }
            return Resultado;
        }
    }
}
