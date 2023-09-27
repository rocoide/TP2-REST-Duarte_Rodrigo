using Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.Response
{
    public class SalaResponse
    {
        public int id {  get; set; }
        public string nombre { get; set; }
        public int capacidad { get; set; }

    }
}
