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

        public async Task<int> GetCantTicketsVendidos(int FuncionId)
        {
            Funcion? Funcion = await Context.Funciones.Include(m => m.Salas).Include(f => f.Tickets).FirstOrDefaultAsync(s => s.FuncionId == FuncionId);
            return Funcion.Tickets.Count;
        }
    }
}
