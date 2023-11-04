using Domain.Entity;

namespace Application.Interface.Funciones
{
    public interface IFuncionQuery
    {
        Task<List<Funcion>> GetFunciones(string? Titulo, string? Fecha, int? GeneroId);
        Task<Funcion?> GetFuncionById(int FuncionId);
    }
}
