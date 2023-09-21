using Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ICineQuery
    {
        Task<List<PeliculaDTO>> getPeliculas();
    }
}
