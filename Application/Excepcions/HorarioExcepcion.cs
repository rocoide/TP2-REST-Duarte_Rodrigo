using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Excepcions
{
    public class HorarioExcepcion : Exception
    {
        public HorarioExcepcion(string Message) : base(Message) { }
    }
}
