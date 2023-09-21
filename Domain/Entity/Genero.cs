using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    [Table("Genero")]
    public class Genero
    {
        public int GeneroId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Nombre { get; set; }

        public ICollection<Pelicula> Peliculas { get; set; }
    }
}
