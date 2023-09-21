using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    [Table("Peliculas")]
    public class Pelicula
    {
        public int PeliculaId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Titulo { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Sinopsis { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Poster { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Trailer { get; set; }


        [ForeignKey("Genero")]
        public int GeneroId { get; set; }
        public Genero Generos { get; set; }
        public ICollection<Funcion> Funciones { get; set; }
    }
}
