using Application.Model.DTO;
using Application.Model.Response;

namespace Application.Interface.Funciones
{
    public interface IFuncionService
    {
        Task<List<FuncionResponse>> GetFunciones(string? Titulo, string? Fecha, int? GeneroId);
        Task<FuncionResponse> AddFuncion(FuncionDTO FuncionDTO);
        Task<FuncionResponse?> GetFuncionById(int FuncionId);




        Task<FuncionRemoveResponse?> RemoveFuncion(int FuncionId);
        
        
        
  
    }
}
