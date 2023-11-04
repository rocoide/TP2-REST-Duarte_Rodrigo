using Application.Model.DTO;
using Domain.Entity;

namespace Application.Mapping
{
    public class MapTicketDTOToListaTickets
    {
        public List<Ticket> Map(TicketDTO TicketDTO, int FuncionId)
        {
            List<Ticket> ListTicket = new List<Ticket>();
            Ticket Ticket;
            for (int i = 0; i < TicketDTO.Cantidad; i++)
            {
                Ticket = new Ticket
                {
                    TicketId = Guid.NewGuid(),
                    FuncionId = FuncionId,
                    Usuario = TicketDTO.Usuario,
                };
                ListTicket.Add(Ticket);
            }
            return ListTicket;
        }
    }
}
