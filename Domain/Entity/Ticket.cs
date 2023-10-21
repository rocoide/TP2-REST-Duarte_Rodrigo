namespace Domain.Entity
{
    public class Ticket
    {
        public Guid TicketId { get; set; }

        public int FuncionId { get; set; }
        public Funcion Funciones { get; set; }

        public string Usuario { get; set; }
    }
}
