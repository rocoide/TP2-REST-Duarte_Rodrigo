using Application.Model;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Pelicula
{
    public interface IPeliculaService
    {
        Task<List<PeliculaDTO>> getPeliculas();
        Task<PeliculaDTO> getPelicula(int id);
    }
}
