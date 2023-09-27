using Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.Response
{
    public class PeliculaResponseShort
    {

        public int peliculaId { get; set; }
        public string titulo { get; set; }
        public string poster { get; set; }
        public GeneroResponse genero { get; set; }

    }
}
