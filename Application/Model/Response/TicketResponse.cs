using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.Response
{
    public class TicketResponse
    {
        public List<TicketIdResponse> TicketIds { get; set; }
        public FuncionResponse Funcion { get; set; }
        public string usuario { get; set; }
    }
}
