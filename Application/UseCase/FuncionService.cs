using Application.Interface.Funciones;
using Application.Model.DTO;
using Application.Model.Response;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class FuncionService : IFuncionService
    {
        private readonly IFuncionCommand _command;
        private readonly IFuncionQuery _query;

        public FuncionService(IFuncionCommand command, IFuncionQuery query)
        {
            _command = command;
            _query = query;
        }

        public async Task<List<FuncionResponse>> getAllFunciones() 
        {
            List<FuncionResponse> lista = await _query.getAllFunciones();
            return lista;
        }

        public async Task<List<FuncionResponse>> getFuncionesByTitulo(string titu) 
        {
            List<FuncionResponse> funciones = await _query.getFuncionesByTitulo(titu);
            return funciones;
        }

        public async Task<List<FuncionResponse>> getFuncionesByFecha(DateTime fecha) 
        {
            List<FuncionResponse> funciones = await _query.getFuncionesByFecha(fecha);
            return funciones;
        }

        public async Task<List<FuncionResponse>> getFuncionesByGenero(int? generoID) 
        {
            List<FuncionResponse> funciones = await _query.getFuncionesByGenero(generoID);
            return funciones;
        }

        public async Task<List<FuncionResponse>> compararFuncionResponse(List<FuncionResponse> funcion1, List<FuncionResponse> funcion2)
        {
            List<FuncionResponse> lista = new List<FuncionResponse>();
            foreach (FuncionResponse fun2 in funcion2)
            {
                foreach (FuncionResponse fun1 in funcion1)
                {
                    if (fun2.funcionId == fun1.funcionId)
                    {
                        lista.Add(fun1);
                    }
                }
            }
            return lista;
        }

        public Task<bool> AddFuncion(Funcion fun) 
        {
            return (_command.AddFuncion(fun));
        }

        public async Task<int?> removeFuncion(int funcionID) 
        {
           return await _command.removeFuncion(funcionID);
        }

        public async Task<int?> getCantTicketsDisponibles(int funcionID) 
        {
            int? resultado = await _query.getCantTicketsDisponibles(funcionID);
            return resultado;
        }

        public async Task<FuncionDTO> getFuncionByID(int funcionID) 
        {
            return await _query.getFuncionByID(funcionID);
        }

    }
}
