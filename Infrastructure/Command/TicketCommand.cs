using Application.Interface.Tickets;
using Application.Model.DTO;
using Application.Model.Response;
using Domain.Entity;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Command
{
    public class TicketCommand : ITicketCommand
    {
        private readonly CineContext Context;

        public TicketCommand(CineContext Context)
        {
            this.Context = Context;
        }

        public async Task<TicketResponse> AddTicket(TicketDTO ticketDTO, int funcionId)
        {
            Ticket ticket;
            TicketIdResponse ticketId;
            List<Ticket> tickets = new List<Ticket>();
            List<TicketIdResponse> ticketIdResponses = new List<TicketIdResponse>();
            for (int i = 0; i < ticketDTO.Cantidad; i++)
            {
                ticket = new Ticket
                {
                    TicketId = new Guid(),
                    Usuario = ticketDTO.Usuario,
                    FuncionId = funcionId
                };
                tickets.Add(ticket);
                Context.Tickets.Add(ticket);
            }
            Context.SaveChanges();

            foreach (Ticket t in tickets)
            {
                ticketId = new TicketIdResponse
                {
                    ticketId = t.TicketId
                };
                ticketIdResponses.Add(ticketId);
            }



            Funcion? funcion = await Context.Funciones
                                             .Include(s => s.Peliculas)
                                                 .ThenInclude(m => m.Generos)
                                             .Include(s => s.Salas)
                                             .FirstOrDefaultAsync(f => f.FuncionId == funcionId);

            FuncionResponse funcionResponse = new FuncionResponse
            {
                FuncionId = funcion.FuncionId,
                Pelicula = new PeliculaGetResponse
                {
                    PeliculaId = funcion.Peliculas.PeliculaId,
                    Titulo = funcion.Peliculas.Titulo,
                    Poster = funcion.Peliculas.Poster,
                    Genero = new GeneroResponse
                    {
                        Id = funcion.Peliculas.Genero,
                        Nombre = funcion.Peliculas.Generos.Nombre
                    }

                },
                Sala = new SalaResponse
                {
                    Id = funcion.SalaId,
                    Nombre = funcion.Salas.Nombre,
                    Capacidad = funcion.Salas.Capacidad
                },
                Fecha = funcion.Fecha,
                Horario = funcion.Horario.ToString(@"hh\:mm")
            };
            TicketResponse ticketResponse = new TicketResponse
            {
                TicketIds = ticketIdResponses,
                Funcion = funcionResponse,
                usuario = ticketDTO.Usuario
            };
            return ticketResponse;
        }
    }
}
