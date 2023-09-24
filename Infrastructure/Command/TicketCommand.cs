using Application.Interface.Tickets;
using Application.Model;
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

        public  async Task<bool> AddTicket(TicketDTO ticketDTO) 
        {
            List<Ticket> lista_tickets = _context.Tickets
                                                                     .Where(f => f.FuncionId == ticketDTO.FuncionId)
                                                                     .ToList();

            Funcion funcion = await _context.Funciones.Include(m => m.Salas).FirstOrDefaultAsync(s => s.FuncionId == ticketDTO.FuncionId);

            if ((lista_tickets == null) || (funcion.Salas.Capacidad > lista_tickets.Count))
            {
                Ticket ticket = await _context.Tickets.FindAsync(ticketDTO.TicketId);
                if (ticket == null)
                {
                    ticket = new Ticket
                    {
                        TicketId = ticketDTO.TicketId,
                        FuncionId = ticketDTO.FuncionId,
                        Usuario = ticketDTO.Usuario,
                    };
                    await _context.Tickets.AddAsync(ticket);
                    _context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}
