namespace Application.Interface.Tickets
{
    public interface ITicketQuery
    {
        Task<int?> GetCantTicketsDisponibles(int FuncionId);
    }
}
