using Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Query
{
    public class CineQuery : ICineQuery
    {
        private readonly CineContext _context;

        public CineQuery(CineContext context) 
        {
            _context = context;
        }

    }
}
