using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Excepcions
{
    public class PeliculaExcepcion : Exception
    {
        public PeliculaExcepcion (string Message) : base(Message) { }
    }
}
