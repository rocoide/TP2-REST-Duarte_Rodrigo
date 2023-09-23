using Application.Interface.Funciones;
using Application.Model;
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

        public async Task<List<FuncionDTO>> getAllFunciones() 
        {
            List<FuncionDTO> lista = await _query.getAllFunciones();
            return lista;
        }

        public async Task<List<FuncionDTO>> getFuncionesByTitulo(string titu) 
        {
            List<FuncionDTO> funciones = await _query.getFuncionesByTitulo(titu);
            return funciones;
        }

        public async Task<List<FuncionDTO>> getFuncionesByFecha(DateTime fecha) 
        {
            List<FuncionDTO> funciones = await _query.getFuncionesByFecha(fecha);
            return funciones;
        }

        public async Task<List<FuncionDTO>> getFuncionesByGenero(int? generoID) 
        {
            List<FuncionDTO> funciones = await _query.getFuncionesByGenero(generoID);
            return funciones;
        }

        public Task<bool> AddFuncion(Funcion fun) 
        {
            return (_command.AddFuncion(fun));
        }
    }
}
