using Domain.Entity;

namespace Application.Interface.Funciones
{
    public interface IFuncionCommand
    {
        Task<Funcion?> AddFuncion(Funcion Fun);
        Task<Funcion?> RemoveFuncion(int FuncionId);
    }
}
