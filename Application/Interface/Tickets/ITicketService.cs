using Application.Model.DTO;
using Application.Model.Response.Tickets;

namespace Application.Interface.Tickets
{
    public interface ITicketService
    {
        Task<TicketCantidadResponse> GetCantTicketsDisponibles(int FuncionId);
        Task<TicketResponse> AddTicket(TicketDTO TicketDTO, int FuncionId);
    }
}
