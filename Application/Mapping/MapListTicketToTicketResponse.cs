using Application.Model.Response.Funciones;
using Application.Model.Response.Tickets;
using Domain.Entity;

namespace Application.Mapping
{
    public class MapListTicketToTicketResponse
    {
        public TicketResponse Map(FuncionResponse FuncionResponse, List<Ticket> ListTicket)
        {
            List<TicketIdResponse> ListaId = new List<TicketIdResponse>();
            TicketIdResponse TicketIdResponse;
            foreach (Ticket Ticket in ListTicket)
            {
                TicketIdResponse = new TicketIdResponse
                {
                    TicketId = Ticket.TicketId
                };
                ListaId.Add(TicketIdResponse);
            };
            TicketResponse TicketResponse = new TicketResponse
            {
                Tickets = ListaId,
                Funcion = FuncionResponse,
                Usuario = ListTicket[0].Usuario
            };
            return TicketResponse;
        }
    }
}
