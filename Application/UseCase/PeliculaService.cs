using Application.Interface.Peliculas;
using Application.Model.DTO;
using Application.Model.Response;
using Domain.Entity;
using System.ComponentModel;

namespace Application.UseCase
{
    public class PeliculaService : IPeliculaService
    {
        private readonly IPeliculaCommand PeliculaCommand;
        private readonly IPeliculaQuery PeliculaQuery;

        public PeliculaService(IPeliculaCommand PeliculaCommand, IPeliculaQuery PeliculaQuery)
        {
            this.PeliculaCommand = PeliculaCommand;
            this.PeliculaQuery = PeliculaQuery;
        }

        public async Task<List<PeliculaDTO>> GetPeliculas()
        {
            List<Pelicula> peliculas = await PeliculaQuery.GetPeliculas();
            //return peliculas;

            List<PeliculaDTO> lista = new List<PeliculaDTO>();
            return lista;
        }

        public async Task<PeliculaResponseLong?> GetPeliculaById(int PeliculaId)
        {
            Pelicula Pelicula = await PeliculaQuery.GetPeliculaById(PeliculaId);
            //return pelicula;

            PeliculaResponseLong? lista = null;
            return lista;
        }
        public async Task<bool> validarCampos(PeliculaIdDTO peliculaIdDTO)
        {
            if (peliculaIdDTO.Titulo.Length > 50)
            {
                return false;
            }
            if (peliculaIdDTO.Sinopsis.Length > 255)
            {
                return false;
            }
            if (peliculaIdDTO.Poster.Length > 100)
            {
                return false;
            }
            if (peliculaIdDTO.Trailer.Length > 100)
            {
                return false;
            }
            return true;
        }

        public async Task<PeliculaResponseLong> updatePelicula(PeliculaIdDTO peliculaIdDTO, int peliculaID)
        {
            Pelicula pelicula = new Pelicula
            {
                PeliculaId = peliculaID,
                Titulo = peliculaIdDTO.Titulo,
                Sinopsis = peliculaIdDTO.Sinopsis,
                Poster = peliculaIdDTO.Poster,
                Trailer = peliculaIdDTO.Trailer,
                Genero = peliculaIdDTO.GeneroId
            };
            return await PeliculaCommand.updatePelicula(pelicula);

        }


    }
}
