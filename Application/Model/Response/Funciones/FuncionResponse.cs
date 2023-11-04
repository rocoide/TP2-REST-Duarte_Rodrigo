using Application.Model.Response.Peliculas;

namespace Application.Model.Response.Funciones
{
    public class FuncionResponse
    {
        public int FuncionId { get; set; }
        public PeliculaGetResponse Pelicula { get; set; }
        public SalaResponse Sala { get; set; }
        public DateTime Fecha { get; set; }
        public string Horario { get; set; }
    }
}
