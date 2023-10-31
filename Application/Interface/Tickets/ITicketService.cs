using Application.Model.DTO;
using Application.Model.Response;

namespace Application.Interface.Tickets
{
    public interface ITicketService
    {
        Task<int?> GetCantTicketsDisponibles(int FuncionId);
        Task<TicketResponse> AddTicket(TicketDTO TicketDTO, int id);
    }
}
