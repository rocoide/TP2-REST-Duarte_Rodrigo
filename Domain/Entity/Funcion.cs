namespace Domain.Entity
{
    public class Funcion
    {
        public int FuncionId { get; set; }

        public int PeliculaId { get; set; }
        public Pelicula Peliculas { get; set; }

        public int SalaId { get; set; }
        public Sala Salas { get; set; }


        public ICollection<Ticket> Tickets { get; set; }

        public DateTime Fecha { get; set; }
        public TimeSpan Horario { get; set; }

    }
}
