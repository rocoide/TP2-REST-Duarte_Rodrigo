using Domain.Entity;

namespace Application.Interface.Generos
{
    public interface IGeneroQuery
    {
        public Task<Genero?> GetGeneroById(int GeneroId);
    }
}
