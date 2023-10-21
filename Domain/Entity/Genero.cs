namespace Domain.Entity
{
    public class Genero
    {
        public int GeneroId { get; set; }
        public string Nombre { get; set; }

        public ICollection<Pelicula> Peliculas { get; set; }
    }
}
