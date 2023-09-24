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

        public async Task<List<FuncionDTO>> compararDTO(List<FuncionDTO> funcion1, List<FuncionDTO> funcion2)
        {
            List<FuncionDTO> lista = new List<FuncionDTO>();
            foreach (FuncionDTO fun2 in funcion2)
            {
                foreach (FuncionDTO fun1 in funcion1)
                {
                    if ((fun2.PeliculaGenero == fun1.PeliculaGenero) && (fun2.PeliculaNombre == fun1.PeliculaNombre) && (fun2.SalaNombre == fun1.SalaNombre) && (fun2.Fecha == fun1.Fecha) && (fun2.Horario == fun1.Horario))
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
    }
}
