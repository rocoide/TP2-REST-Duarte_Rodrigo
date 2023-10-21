namespace Application.Model.Response
{
    public class PeliculaResponseLong
    {
        public int peliculaId { get; set; }
        public string titulo { get; set; }
        public string poster { get; set; }
        public string trailer { get; set; }
        public string sinopsis { get; set; }
        public GeneroResponse genero { get; set; }
        public List<FuncionResponseShort> funciones { get; set; }
    }
}
