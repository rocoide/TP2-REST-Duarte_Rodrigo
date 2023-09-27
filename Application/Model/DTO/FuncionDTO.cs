using Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.DTO
{
    public class FuncionDTO
    {
        public string Fecha { get; set; }
        public string Horario { get; set; }
        public string Dia { get; set; }
        public string PeliculaNombre { get; set; }
        public string PeliculaGenero { get; set; }
        public string SalaNombre { get; set; }
    }
}
