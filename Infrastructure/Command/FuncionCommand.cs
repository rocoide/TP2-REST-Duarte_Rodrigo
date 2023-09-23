using Application.Interface.Funciones;
using Domain.Entity;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Command
{
    public class FuncionCommand : IFuncionCommand
    {
        private readonly CineContext _context;

        public FuncionCommand(CineContext context)
        {
            _context = context;
        }
        public async Task<bool> AddFuncion(Funcion fun) 
        {
            TimeSpan tiempo_agregado = new TimeSpan(2,30,0);
            TimeSpan aux = fun.Horario + TimeSpan.FromHours(-2) + TimeSpan.FromMinutes(-30); //auxiliar para simular la comparacion con el fin de las peliculas en cartelera
            TimeSpan hora_fin = fun.Horario.Add(tiempo_agregado);
            List<Funcion> funciones = _context.Funciones
                                                                .Where(f => (f.SalaId == fun.SalaId) && 
                                                                                    (f.Fecha.Month == fun.Fecha.Month) && 
                                                                                    (f.Fecha.Day == fun.Fecha.Day) &&
                                                                                    (
                                                                                        (
                                                                                            (f.Horario >= fun.Horario && f.Horario < hora_fin) ||
                                                                                            (f.Horario <= fun.Horario && f.Horario > aux)
                                                                                        )
                                                                                    )
                                                                            )
                                                                .ToList();
            if (funciones.Count == 0) 
            {
                _context.Funciones.Add(fun);
                _context.SaveChanges();
                return true;
            }
            else 
            {
                return false;
            }
        }
    }
}
