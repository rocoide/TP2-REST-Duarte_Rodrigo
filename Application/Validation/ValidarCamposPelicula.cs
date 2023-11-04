using Application.Model.DTO;

namespace Application.Validation
{
    public static class ValidarCamposPelicula
    {
        public static void Validar(PeliculaDTO PeliculaDTO)
        {
            if (PeliculaDTO.Titulo.Length > 50)
            {
                throw new FormatException("El titulo no debe tener mas de 50 caracteres");
            }
            if (PeliculaDTO.Sinopsis.Length > 255)
            {
                throw new FormatException("La sinopsis no debe tener mas de 255 caracteres");
            }
            if (PeliculaDTO.Poster.Length > 100)
            {
                throw new FormatException("La URL del poster no debe tener mas 100 caracteres");
            }
            if (PeliculaDTO.Trailer.Length > 100)
            {
                throw new FormatException("La URL del trailer no debe ser mayor de 100 caracteres.");
            }
            if (PeliculaDTO.Titulo.Length < 1)
            {
                throw new FormatException("El titulo debe tener al menos 1 caracter.");
            }
            if (PeliculaDTO.Sinopsis.Length < 1)
            {
                throw new FormatException("La sinopsis debe tener al menos 1 caracter.");
            }
            if (PeliculaDTO.Poster.Length < 1)
            {
                throw new FormatException("La URL del poster debe tener al menos 1 caracter.");
            }
            if (PeliculaDTO.Trailer.Length < 1)
            {
                throw new FormatException("La URL del trailer debe tener al menos 1 caracter.");
            }
        }
    }
}
