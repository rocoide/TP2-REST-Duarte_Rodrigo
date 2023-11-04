using Application.Model.Response;
using Application.Model.Response.Funciones;
using Application.Model.Response.Peliculas;
using Domain.Entity;

namespace Application.Mapping
{
    public class MappingFuncionesToFuncionesResponse
    {
        public List<FuncionResponse> Map(List<Funcion> ListaFuncion)
        {
            List<FuncionResponse> ListaResponse = new List<FuncionResponse>();
            foreach (Funcion Funcion in ListaFuncion)
            {
                ListaResponse.Add(Map(Funcion));
            }
            return ListaResponse;
        }

        public FuncionResponse Map(Funcion Funcion)
        {
            return new FuncionResponse
            {
                FuncionId = Funcion.FuncionId,
                Pelicula = new PeliculaGetResponse
                {
                    PeliculaId = Funcion.PeliculaId,
                    Titulo = Funcion.Peliculas.Titulo,
                    Poster = Funcion.Peliculas.Poster,
                    Genero = new GeneroResponse
                    {
                        Id = Funcion.Peliculas.Genero,
                        Nombre = Funcion.Peliculas.Generos.Nombre
                    },
                },
                Sala = new SalaResponse
                {
                    Id = Funcion.SalaId,
                    Nombre = Funcion.Salas.Nombre,
                    Capacidad = Funcion.Salas.Capacidad
                },
                Fecha = Funcion.Fecha,
                Horario = Funcion.Horario.ToString(@"hh\:mm"),
            };
        }
    }
}
