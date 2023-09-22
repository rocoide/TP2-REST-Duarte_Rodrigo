using Application.Interface.Pelicula;
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
    public class PeliculaCommand : IPeliculaCommand
    {
        private readonly CineContext _context;

        public PeliculaCommand(CineContext context)
        {
            _context = context;
        }

    }
}
