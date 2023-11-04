using Application.Model.Response.Funciones;

namespace Application.Model.Response.Peliculas
{
    public class PeliculaResponse
    {
        public int PeliculaId { get; set; }
        public string Titulo { get; set; }
        public string Poster { get; set; }
        public string Trailer { get; set; }
        public string Sinopsis { get; set; }
        public GeneroResponse Genero { get; set; }
        public List<FuncionRemoveResponse> Funciones { get; set; }
    }
}
