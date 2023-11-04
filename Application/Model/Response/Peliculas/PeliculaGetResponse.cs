namespace Application.Model.Response.Peliculas
{
    public class PeliculaGetResponse
    {

        public int PeliculaId { get; set; }
        public string Titulo { get; set; }
        public string Poster { get; set; }
        public GeneroResponse Genero { get; set; }
    }
}
