using Application.Model;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Funciones
{
    public interface IFuncionService
    {
        Task<List<FuncionDTO>> getAllFunciones();
        Task<List<FuncionDTO>> getFuncionesByTitulo(string titu);
        Task<List<FuncionDTO>> getFuncionesByFecha(DateTime fecha);
        Task<List<FuncionDTO>> getFuncionesByGenero(int? generoID);
        Task<List<FuncionDTO>> compararDTO(List<FuncionDTO> funcion1, List<FuncionDTO> funcion2);
        Task<bool> AddFuncion(Funcion fun);
    }
}
