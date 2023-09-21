using Application.Interface;
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
    public class CineCommand : ICineCommand
    {
        private readonly CineContext _context;

        public CineCommand(CineContext context)
        {
            _context = context;
        }

    }
}
