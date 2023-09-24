using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Tickets
{
    public interface ITicketService
    {
         Task<bool> AddTicket(string usuario, int funcionID);
    }
}
