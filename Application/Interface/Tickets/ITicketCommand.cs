using Domain.Entity;

namespace Application.Interface.Tickets
{
    public interface ITicketCommand
    {
        Task AddTicket(List<Ticket> ListTicket);
    }
}
