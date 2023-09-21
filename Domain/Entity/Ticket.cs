using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    [Table("Tickets")]
    public class Ticket
    {
        [Column(Order = 1)]
        public Guid TicketId { get; set; }

        [Column(Order = 3, TypeName = "nvarchar(50)")]
        public string Usuario { get; set; }

        //cambia el orden de la columna y el nombre con el que se mapea
        [Column("funcionID", Order = 2)]
        public int FuncionId { get; set; }
        public Funcion Funciones { get; set; }
    }
}
