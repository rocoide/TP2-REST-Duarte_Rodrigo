using Application.Interface.Tickets;
using Domain.Entity;
using Infrastructure.Persistence;

namespace Infrastructure.Command
{
    public class TicketCommand : ITicketCommand
    {
        private readonly CineContext Context;

        public TicketCommand(CineContext Context)
        {
            this.Context = Context;
        }

        public async Task AddTicket(List<Ticket> ListTicket)
        {
            foreach (Ticket Ticket in ListTicket)
            {
                await Context.Tickets.AddAsync(Ticket);
                await Context.SaveChangesAsync();
            }
        }
    }
}
