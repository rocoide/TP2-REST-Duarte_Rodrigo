using Application.Model.DTO;
using Application.Model.Response;

namespace Application.Interface.Tickets
{
    public interface ITicketCommand
    {
        Task<TicketResponse> AddTicket(TicketDTO ticketDTO, int funcionId);
    }
}
