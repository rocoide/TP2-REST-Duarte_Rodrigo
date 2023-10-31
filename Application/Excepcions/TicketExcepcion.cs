using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Excepcions
{
    public class TicketExcepcion : Exception
    {
        public TicketExcepcion(string Message) : base (Message) { }
    }
}
