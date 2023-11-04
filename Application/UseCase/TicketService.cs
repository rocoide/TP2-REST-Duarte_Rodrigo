using Application.Excepcions;
using Application.Interface.Funciones;
using Application.Interface.Tickets;
using Application.Mapping;
using Application.Model.DTO;
using Application.Model.Response.Funciones;
using Application.Model.Response.Tickets;
using Domain.Entity;

namespace Application.UseCase
{
    public class TicketService : ITicketService
    {
        private readonly ITicketCommand TicketCommand;
        private readonly ITicketQuery TicketQuery;
        private readonly IFuncionQuery FuncionQuery;

        public TicketService(ITicketCommand TicketCommand, ITicketQuery TicketQuery, IFuncionQuery FuncionQuery)
        {
            this.TicketCommand = TicketCommand;
            this.TicketQuery = TicketQuery;
            this.FuncionQuery = FuncionQuery;
        }

        public async Task<TicketCantidadResponse> GetCantTicketsDisponibles(int FuncionId)
        {
            Funcion? Funcion = await FuncionQuery.GetFuncionById(FuncionId);
            if (Funcion == null)
            {
                throw new NotFoundExcepcion("No Existe la funcion ingresada.");
            }
            int TicketsVendidos = await TicketQuery.GetCantTicketsVendidos(FuncionId);
            TicketCantidadResponse TicketCantidadResponse = new TicketCantidadResponse
            {
                Cantidad = (Funcion.Salas.Capacidad - TicketsVendidos)
            };
            return TicketCantidadResponse;
        }

        public async Task<TicketResponse> AddTicket(TicketDTO TicketDTO, int FuncionId)
        {
            Funcion? Funcion = await FuncionQuery.GetFuncionById(FuncionId);
            if (Funcion == null)
            {
                throw new NotFoundExcepcion("No Existe la funcion ingresada.");
            }
            int TicketsVendidos = await TicketQuery.GetCantTicketsVendidos(FuncionId);
            if (Funcion.Salas.Capacidad < (TicketDTO.Cantidad + TicketsVendidos))
            {
                throw new ConflicExcepcion("No hay suficiente tickets para completar la operacion.");
            }
            MapTicketDTOToListaTickets Mapping = new MapTicketDTOToListaTickets();
            List<Ticket> ListTicket = Mapping.Map(TicketDTO, FuncionId);
            await TicketCommand.AddTicket(ListTicket);

            MappingFuncionesToFuncionesResponse Mapping2 = new MappingFuncionesToFuncionesResponse();
            FuncionResponse FuncionResponse = Mapping2.Map(Funcion);

            MapListTicketToTicketResponse Mapping3 = new MapListTicketToTicketResponse();
            TicketResponse TicketResponse = Mapping3.Map(FuncionResponse, ListTicket);
            return TicketResponse;
        }

    }
}
