using Application.Model.Response;
using Domain.Entity;

namespace Application.Interface.Funciones
{
    public interface IFuncionCommand
    {
        Task<FuncionResponse> AddFuncion(Funcion fun);
        Task<FuncionRemoveResponse?> removeFuncion(int funcionID);
    }
}
