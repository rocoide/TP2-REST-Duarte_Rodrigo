﻿using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Funciones
{
    public interface IFuncionCommand
    {
        Task<bool> AddFuncion(Funcion fun);
        Task<bool> removeFuncion(int funcionID);
    }
}