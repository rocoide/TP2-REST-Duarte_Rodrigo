using Application.Interface.Pelicula;
using Application.Model;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class PeliculaService : IPeliculaService
    {
        private readonly IPeliculaCommand _command;
        private readonly IPeliculaQuery _query;

        public PeliculaService (IPeliculaCommand command, IPeliculaQuery query) 
        {
            _command = command;
            _query = query;
        }

        public async Task<List<PeliculaDTO>> getPeliculas() 
        {
            List<PeliculaDTO> peliculas = await _query.getPeliculas();
            return peliculas;
        }

        public async Task<PeliculaDTO> getPelicula(int id) 
        {
            PeliculaDTO pelicula = await _query.getPelicula(id);
            return pelicula;
        }
    }
}
