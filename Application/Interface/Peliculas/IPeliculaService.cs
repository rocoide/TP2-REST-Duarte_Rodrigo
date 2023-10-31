using Application.Model.DTO;
using Application.Model.Response;

namespace Application.Interface.Peliculas
{
    public interface IPeliculaService
    {
        Task<List<PeliculaDTO>> GetPeliculas();
        Task<PeliculaResponseLong> GetPeliculaById(int PeliculaId);
        Task<bool> validarCampos(PeliculaIdDTO peliculaIdDTO);
        Task<PeliculaResponseLong> updatePelicula(PeliculaIdDTO peliculaIdDTO, int peliculaID);
    }
}
