using Application.Model.DTO;
using Domain.Entity;

namespace Application.Mapping
{
    public class MapFuncionDTOToFuncion
    {
        public Funcion Map(FuncionDTO FuncionDTO)
        {
            return new Funcion
            {
                PeliculaId = FuncionDTO.Pelicula,
                SalaId = FuncionDTO.Sala,
                Fecha = FuncionDTO.Fecha,
                Horario = TimeSpan.Parse(FuncionDTO.Horario),
            };
        }
    }
}
