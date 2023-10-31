using Application.Model.DTO;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class MapFuncionDTOToFuncion
    {
        public Funcion Map(FuncionDTO FuncionDTO) 
        {
            return new Funcion
            {
                PeliculaId = FuncionDTO.PeliculaId,
                SalaId = FuncionDTO.SalaId,
                Fecha = FuncionDTO.Fecha,
                Horario = TimeSpan.Parse(FuncionDTO.Horario),
            };
        }
    }
}
