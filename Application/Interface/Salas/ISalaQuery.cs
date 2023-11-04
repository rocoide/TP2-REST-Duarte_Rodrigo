using Domain.Entity;

namespace Application.Interface.Salas
{
    public interface ISalaQuery
    {
        public Task<Sala?> GetSalaById(int SalaId);
    }
}
