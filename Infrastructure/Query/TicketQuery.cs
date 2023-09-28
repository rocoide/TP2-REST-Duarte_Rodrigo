using Application.Interface.Tickets;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Query
{
    public class TicketQuery : ITicketQuery
    {
        private readonly CineContext _context;

        public TicketQuery(CineContext context)
        {
            _context = context;
        }

        public async Task<int?> getCantTicketsDisponibles(int funcionID)
        {
            int resultado;
            Funcion funcion = _context.Funciones.Include(m => m.Salas).FirstOrDefault(s => s.FuncionId == funcionID);
            if (funcion == null)
            {
                return null;
            }
            else
            {
                List<Ticket> lista_tickets = _context.Tickets
                                                     .Where(s => s.FuncionId == funcionID)
                                                     .ToList();
                resultado = (funcion.Salas.Capacidad - lista_tickets.Count);
            }
            return resultado;
        }
    }
}
