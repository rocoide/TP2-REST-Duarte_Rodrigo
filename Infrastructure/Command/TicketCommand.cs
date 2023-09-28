using Application.Interface.Tickets;
using Application.Model.DTO;
using Application.Model.Response;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Command
{
    public class TicketCommand : ITicketCommand
    {
        private readonly CineContext _context;

        public TicketCommand(CineContext context)
        {
            _context = context;
        }

        public  async Task<TicketResponse> AddTicket(TicketDTO ticketDTO, int funcionId)
        {
            Ticket ticket;
            TicketIdResponse ticketId;
            List<Ticket> tickets = new List<Ticket>();
            List<TicketIdResponse> ticketIdResponses = new List<TicketIdResponse>();
            for (int i = 0; i < ticketDTO.cantidad; i++)
            {
                ticket = new Ticket
                {
                    TicketId = new Guid(),
                    Usuario = ticketDTO.Usuario,
                    FuncionId = funcionId
                };
                tickets.Add(ticket);
                _context.Tickets.Add(ticket);
            }
            _context.SaveChanges();

            foreach(Ticket t in tickets) 
            {
                ticketId = new TicketIdResponse
                {
                    ticketId = t.TicketId
                };
                ticketIdResponses.Add(ticketId);
            }



            Funcion? funcion = await _context.Funciones
                                             .Include(s => s.Peliculas)
                                                 .ThenInclude(m => m.Generos)
                                             .Include(s => s.Salas)
                                             .FirstOrDefaultAsync(f => f.FuncionId == funcionId);

            FuncionResponse funcionResponse = new FuncionResponse
            {
                funcionId = funcion.FuncionId,
                pelicula = new PeliculaResponseShort
                {
                    peliculaId = funcion.Peliculas.PeliculaId,
                    titulo = funcion.Peliculas.Titulo,
                    poster = funcion.Peliculas.Poster,
                    genero = new GeneroResponse
                    {
                        id = funcion.Peliculas.GeneroId,
                        nombre = funcion.Peliculas.Generos.Nombre
                    }

                },
                sala = new SalaResponse
                {
                    id = funcion.SalaId,
                    nombre = funcion.Salas.Nombre,
                    capacidad = funcion.Salas.Capacidad
                },
                fecha = funcion.Fecha,
                horario = funcion.Horario.ToString(@"hh\:mm")
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
