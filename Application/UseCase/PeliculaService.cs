using Application.Excepcions;
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

        public PeliculaService(IPeliculaCommand PeliculaCommand, IPeliculaQuery PeliculaQuery)
        {
            this.PeliculaCommand = PeliculaCommand;
            this.PeliculaQuery = PeliculaQuery;
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
