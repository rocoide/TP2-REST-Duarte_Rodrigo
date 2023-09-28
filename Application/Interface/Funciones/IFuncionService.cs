using Application.Model.DTO;
using Application.Model.Response;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Funciones
{
    public interface IFuncionService
    {
        Task<List<FuncionResponse>> getAllFunciones();
        Task<List<FuncionResponse>> getFuncionesByTitulo(string titu);
        Task<List<FuncionResponse>> getFuncionesByFecha(DateTime fecha);
        Task<List<FuncionResponse>> getFuncionesByGenero(int? generoID);
        Task<List<FuncionResponse>> compararFuncionResponse(List<FuncionResponse> funcion1, List<FuncionResponse> funcion2);
        Task<FuncionResponse> AddFuncion(FuncionIdDTO funcionIdDTO);
        Task<FuncionRemoveResponse?> removeFuncion(int funcionID);
        Task<FuncionResponse> getFuncionByID(int funcionID);
    }
}
