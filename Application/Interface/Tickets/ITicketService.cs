using Application.Model.DTO;
using Application.Model.Response;

namespace Application.Interface.Tickets
{
    public interface ITicketService
    {
        Task<int?> getCantTicketsDisponibles(int funcionID);
        Task<TicketResponse> AddTicket(TicketDTO ticketDTO, int id);
    }
}
