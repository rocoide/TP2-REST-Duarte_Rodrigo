using Application.Model.Response;
using Domain.Entity;

namespace Application.Interface.Funciones
{
    public interface IFuncionQuery
    {
        Task<List<Funcion>> GetFunciones(string? Titulo, string? Fecha, int? GeneroId);
        Task<Funcion?> GetFuncionByID(int FuncionID);
    }
}
