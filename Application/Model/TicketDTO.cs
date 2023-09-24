using Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model
{
    public class TicketDTO
    {
        public Guid TicketId { get; set; }
        public string Usuario { get; set; }
        public int FuncionId { get; set; }
    }
}
