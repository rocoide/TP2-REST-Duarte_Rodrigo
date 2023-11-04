namespace Application.Interface.Tickets
{
    public interface ITicketQuery
    {
        Task<int> GetCantTicketsVendidos(int FuncionId);
    }
}
