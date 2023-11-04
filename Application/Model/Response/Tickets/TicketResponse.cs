using Application.Model.Response.Funciones;

namespace Application.Model.Response.Tickets
{
    public class TicketResponse
    {
        public List<TicketIdResponse> Tickets { get; set; }
        public FuncionResponse Funcion { get; set; }
        public string Usuario { get; set; }
    }
}
