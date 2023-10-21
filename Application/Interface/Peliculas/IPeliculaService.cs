using Application.Model.DTO;
using Application.Model.Response;

namespace Application.Interface.Peliculas
{
    public interface IPeliculaService
    {
        Task<List<PeliculaDTO>> getPeliculas();
        Task<PeliculaResponseLong> getPelicula(int id);
        Task<bool> validarCampos(PeliculaIdDTO peliculaIdDTO);
        Task<PeliculaResponseLong> updatePelicula(PeliculaIdDTO peliculaIdDTO, int peliculaID);
    }
}
