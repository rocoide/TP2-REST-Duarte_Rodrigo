using Application.Excepcions;
using Application.Interface.Generos;
using Application.Interface.Peliculas;
using Application.Mapping;
using Application.Model.DTO;
using Application.Model.Response.Peliculas;
using Domain.Entity;

namespace Application.UseCase
{
    public class PeliculaService : IPeliculaService
    {
        private readonly IPeliculaCommand PeliculaCommand;
        private readonly IPeliculaQuery PeliculaQuery;
        private readonly IGeneroQuery GeneroQuery;

        public PeliculaService(IPeliculaCommand PeliculaCommand, IPeliculaQuery PeliculaQuery, IGeneroQuery GeneroQuery)
        {
            this.PeliculaCommand = PeliculaCommand;
            this.PeliculaQuery = PeliculaQuery;
            this.GeneroQuery = GeneroQuery;
        }

        public async Task<PeliculaResponse> GetPeliculaById(int PeliculaId)
        {
            Pelicula? Pelicula = await PeliculaQuery.GetPeliculaById(PeliculaId);
            if (Pelicula == null)
            {
                throw new NotFoundExcepcion("No Existe la pelicula solicitada.");
            }
            MappingPeliculaToPeliculaResponse Mapping = new MappingPeliculaToPeliculaResponse();
            PeliculaResponse PeliculaResponse = Mapping.Map(Pelicula);
            return PeliculaResponse;
        }


        public async Task<PeliculaResponse> UpdatePelicula(PeliculaDTO PeliculaDTO, int PeliculaId)
        {
            Genero? Genero = await GeneroQuery.GetGeneroById(PeliculaDTO.Genero);
            if (Genero == null)
            {
                throw new FormatException("No se encontro un genero asociado al ID ingresado.");
            }
            Pelicula? Pelicula = await PeliculaQuery.GetPeliculaById(PeliculaId);
            if (Pelicula == null)
            {
                throw new NotFoundExcepcion("No existe la pelicula solicitada.");
            }
            Pelicula = await PeliculaCommand.UpdatePelicula(PeliculaDTO, PeliculaId);
            if (Pelicula == null)
            {
                throw new ConflicExcepcion("Ya existe una pelicula con ese titulo en cartelera.");
            }
            MappingPeliculaToPeliculaResponse Mapping = new MappingPeliculaToPeliculaResponse();
            PeliculaResponse PeliculaResponse = Mapping.Map(Pelicula);
            return PeliculaResponse;
        }
    }
}
