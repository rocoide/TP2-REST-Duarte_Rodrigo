using Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Peliculas
{
    public interface IPeliculaQuery
    {
        Task<List<PeliculaDTO>> getPeliculas();
        Task<PeliculaDTO> getPelicula(int id);
    }
}
