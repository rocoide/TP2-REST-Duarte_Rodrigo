using Application.Model.Response;
using Application.Model.Response.Funciones;
using Application.Model.Response.Peliculas;
using Domain.Entity;

namespace Application.Mapping
{
    public class MappingPeliculaToPeliculaResponse
    {
        public PeliculaResponse Map(Pelicula Pelicula)
        {
            List<FuncionRemoveResponse> ListaFunciones = new List<FuncionRemoveResponse>();
            FuncionRemoveResponse FuncionRemoveResponse;
            foreach (Funcion Funcion in Pelicula.Funciones)
            {
                FuncionRemoveResponse = new FuncionRemoveResponse
                {
                    Fecha = Funcion.Fecha,
                    FuncionId = Funcion.FuncionId,
                    Horario = Funcion.Horario.ToString(@"hh\:mm")
                };
                ListaFunciones.Add(FuncionRemoveResponse);
            }
            PeliculaResponse PeliculaResponse = new PeliculaResponse
            {
                PeliculaId = Pelicula.PeliculaId,
                Titulo = Pelicula.Titulo,
                Poster = Pelicula.Poster,
                Trailer = Pelicula.Trailer,
                Sinopsis = Pelicula.Sinopsis,
                Genero = new GeneroResponse
                {
                    Id = Pelicula.Generos.GeneroId,
                    Nombre = Pelicula.Generos.Nombre
                },
                Funciones = ListaFunciones
            };
            return PeliculaResponse;
        }

    }
}
