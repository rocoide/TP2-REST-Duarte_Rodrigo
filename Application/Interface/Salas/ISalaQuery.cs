using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Salas
{
    public interface ISalaQuery
    {
        public Task<Sala?> GetSalaById(int SalaId);
    }
}
