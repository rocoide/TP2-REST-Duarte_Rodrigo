using Application.Interface.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Query
{
    public class TicketQuery : ITicketQuery
    {
        private readonly CineContext _context;

        public TicketQuery(CineContext context)
        {
            _context = context;
        }
    }
}
