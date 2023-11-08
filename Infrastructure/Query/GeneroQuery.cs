using Application.Interface.Generos;
using Domain.Entity;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class GeneroQuery : IGeneroQuery
    {
        private readonly CineContext Context;

        public GeneroQuery(CineContext Context)
        {
            this.Context = Context;
        }

        public async Task<Genero?> GetGeneroById(int GeneroId)
        {
            Genero? Genero = await Context.Generos.FirstOrDefaultAsync(s => s.GeneroId == GeneroId);
            return Genero;
        }
    }
}
