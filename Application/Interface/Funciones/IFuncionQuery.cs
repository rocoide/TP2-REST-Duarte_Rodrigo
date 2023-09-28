using Application.Model.DTO;
using Application.Model.Response;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
