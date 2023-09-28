using Application.Model.DTO;
using Application.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Tickets
{
    public interface ITicketCommand
    {
        Task<TicketResponse> AddTicket(TicketDTO ticketDTO, int funcionId);
    }
}
