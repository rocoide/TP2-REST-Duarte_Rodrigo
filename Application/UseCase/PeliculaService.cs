using Application.Interface.Peliculas;
using Application.Model.DTO;
using Application.Model.Response;
using Domain.Entity;

namespace Application.UseCase
{
    public class PeliculaService : IPeliculaService
    {
        private readonly IPeliculaCommand _command;
        private readonly IPeliculaQuery _query;

        public PeliculaService(IPeliculaCommand command, IPeliculaQuery query)
        {
            _command = command;
            _query = query;
        }

        public async Task<List<PeliculaDTO>> getPeliculas()
        {
            List<PeliculaDTO> peliculas = await _query.getPeliculas();
            return peliculas;
        }

        public async Task<PeliculaResponseLong> getPelicula(int id)
        {
            PeliculaResponseLong pelicula = await _query.getPelicula(id);
            return pelicula;
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
            return await _command.updatePelicula(pelicula);

        }


    }
}
