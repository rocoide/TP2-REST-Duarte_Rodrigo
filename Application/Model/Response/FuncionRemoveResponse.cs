using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.Response
{
    public class FuncionRemoveResponse
    {
        public int funcionId {  get; set; }
        public DateTime fecha { get; set; }
        public string horario { get; set; }
    }
}
