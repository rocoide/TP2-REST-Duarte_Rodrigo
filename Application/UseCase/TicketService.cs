using Application.Interface.Tickets;
using Application.Model.DTO;
using Application.Model.Response;

namespace Application.UseCase
{
    public class TicketService : ITicketService
    {
        private readonly ITicketCommand TicketCommand;
        private readonly ITicketQuery TicketQuery;

        public TicketService(ITicketCommand TicketCommand, ITicketQuery TicketQuery)
        {
            this.TicketCommand = TicketCommand;
            this.TicketQuery = TicketQuery;
        }
        
        public async Task<int?> GetCantTicketsDisponibles(int FuncionId)
        {
            int? Resultado = await TicketQuery.GetCantTicketsDisponibles(FuncionId);
            return Resultado;
        }




        public async Task<TicketResponse> AddTicket(TicketDTO ticketDTO, int id)
        {
            return await TicketCommand.AddTicket(ticketDTO, id);
        }

    }
}
