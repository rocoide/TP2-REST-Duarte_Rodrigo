using Application.Interface.Funciones;
using Application.Interface.Tickets;
using Application.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class TicketService : ITicketService
    {
        private readonly ITicketCommand _command;
        private readonly ITicketQuery _query;

        public TicketService(ITicketCommand command, ITicketQuery query)
        {
            _command = command;
            _query = query;
        }

        public async Task<bool> AddTicket(string usuario, int funcionID)
        {
            Guid guid = Guid.NewGuid();
            TicketDTO ticketDTO = new TicketDTO
            {
                TicketId = guid,
                Usuario = usuario,
                FuncionId = funcionID
            };
            return await _command.AddTicket(ticketDTO);
        }


    }
}
