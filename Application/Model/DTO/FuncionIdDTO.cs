using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.DTO
{
    public class FuncionIdDTO
    {
        public int PeliculaId { get; set; }
        public int SalaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Horario { get; set; }
    }
}
