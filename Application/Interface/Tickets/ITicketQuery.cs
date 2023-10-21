namespace Application.Interface.Tickets
{
    public interface ITicketQuery
    {
        Task<int?> getCantTicketsDisponibles(int funcionID);
    }
}
