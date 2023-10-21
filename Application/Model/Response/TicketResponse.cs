namespace Application.Model.Response
{
    public class TicketResponse
    {
        public List<TicketIdResponse> TicketIds { get; set; }
        public FuncionResponse Funcion { get; set; }
        public string usuario { get; set; }
    }
}
