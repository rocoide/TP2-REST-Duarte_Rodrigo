using Application.Interface.Salas;
using Domain.Entity;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Query
{
    public class SalaQuery : ISalaQuery
    {
        private readonly CineContext Context;
        public SalaQuery(CineContext Context) 
        {
            this.Context = Context;
        }

        public async Task<Sala?> GetSalaById(int SalaId)
        {
            Sala? Sala = await Context.Salas.FirstOrDefaultAsync(s => s.SalaId == SalaId);
            return Sala;
        }
    }
}
