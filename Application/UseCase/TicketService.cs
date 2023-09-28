using Application.Interface.Funciones;
using Application.Interface.Tickets;
using Application.Model.DTO;
using Application.Model.Response;
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

        public async Task<TicketResponse> AddTicket(TicketDTO ticketDTO, int id)
        {
            return await _command.AddTicket (ticketDTO, id);
        }


        public async Task<int?> getCantTicketsDisponibles(int funcionID)
        {
            int? resultado = await _query.getCantTicketsDisponibles(funcionID);
            return resultado;
        }


    }
}
