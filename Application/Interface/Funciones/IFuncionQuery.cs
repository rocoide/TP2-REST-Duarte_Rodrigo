﻿using Application.Model;
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
        Task<List<FuncionDTO>> getAllFunciones();
        Task<List<FuncionDTO>> getFuncionesByTitulo(string titu);
        Task<List<FuncionDTO>> getFuncionesByFecha(DateTime fecha);
        Task<List<FuncionDTO>> getFuncionesByGenero(int? generoID);
    }
}