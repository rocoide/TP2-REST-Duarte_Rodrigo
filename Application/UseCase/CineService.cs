using Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class CineService : ICineService
    {
        private readonly ICineCommand _command;
        private readonly ICineQuery _query;

        public CineService (ICineCommand command, ICineQuery query) 
        {
            _command = command;
            _query = query;
        }


    }
}
