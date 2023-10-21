using Application.Model.Response;

namespace Application.Interface.Funciones
{
    public interface IFuncionQuery
    {
        Task<List<FuncionResponse>> getAllFunciones();
        Task<List<FuncionResponse>> getFuncionesByTitulo(string titu);
        Task<List<FuncionResponse>> getFuncionesByFecha(DateTime fecha);
        Task<List<FuncionResponse>> getFuncionesByGenero(int? generoID);
        Task<FuncionResponse> getFuncionByID(int funcionID);
    }
}
