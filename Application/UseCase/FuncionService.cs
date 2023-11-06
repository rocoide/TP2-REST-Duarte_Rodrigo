using Application.Excepcions;
using Application.Interface.Funciones;
using Application.Interface.Peliculas;
using Application.Interface.Salas;
using Application.Mapping;
using Application.Model.DTO;
using Application.Model.Response.Funciones;
using Application.Validation;
using Domain.Entity;

namespace Application.UseCase
{
    public class FuncionService : IFuncionService
    {
        private readonly IFuncionCommand FuncionCommand;
        private readonly IFuncionQuery FuncionQuery;
        private readonly ISalaQuery SalaQuery;
        private readonly IPeliculaQuery PeliculaQuery;

        public FuncionService(IFuncionCommand FuncionCommand, IFuncionQuery FuncionQuery, ISalaQuery SalaQuery, IPeliculaQuery PeliculaQuery)
        {
            this.FuncionCommand = FuncionCommand;
            this.FuncionQuery = FuncionQuery;
            this.SalaQuery = SalaQuery;
            this.PeliculaQuery = PeliculaQuery;
        }

        public async Task<List<FuncionResponse>> GetFunciones(string? Titulo, string? Fecha, int? GeneroId)
        {
            List<Funcion> Funciones = await FuncionQuery.GetFunciones(Titulo, Fecha, GeneroId);
            MappingFuncionesToFuncionesResponse Mapping = new MappingFuncionesToFuncionesResponse();
            List<FuncionResponse> ListaResponse = Mapping.Map(Funciones);
            return ListaResponse;
        }

        public async Task<FuncionResponse> AddFuncion(FuncionDTO FuncionDTO)
        {
            if (!ValidarHora.validar(FuncionDTO.Horario))
            {
                throw new FormatException("El horario no se ingreso en un formato valido.");
            }
            Sala? Sala = await SalaQuery.GetSalaById(FuncionDTO.Sala);
            if (Sala == null)
            {
                throw new NotFoundExcepcion("La sala ingresada no existe.");
            }
            Pelicula? Pelicula = await PeliculaQuery.GetPeliculaById(FuncionDTO.Pelicula);
            if (Pelicula == null)
            {
                throw new NotFoundExcepcion("La pelicula ingresada ingresada no existe.");
            }
            MapFuncionDTOToFuncion Mapping = new MapFuncionDTOToFuncion();
            Funcion? Fun = Mapping.Map(FuncionDTO);
            MappingFuncionesToFuncionesResponse Mapping2 = new MappingFuncionesToFuncionesResponse();
            Fun = await FuncionCommand.AddFuncion(Fun);
            if (Fun == null)
            {
                throw new ConflicExcepcion("No se pudo agregar correctamente la funcion debido a que ese horario se encuentra ocupado.");
            }
            else
            {
                FuncionResponse FuncionResponse = Mapping2.Map(Fun);
                return FuncionResponse;
            }
        }

        public async Task<FuncionResponse> GetFuncionById(int FuncionId)
        {
            Funcion? Funcion = await FuncionQuery.GetFuncionById(FuncionId);
            if (Funcion == null)
            {
                throw new NotFoundExcepcion("No se encontro la funcion solicitada.");
            }
            MappingFuncionesToFuncionesResponse Mapping = new MappingFuncionesToFuncionesResponse();
            FuncionResponse FuncionResponse = Mapping.Map(Funcion);
            return FuncionResponse;
        }

        public async Task<FuncionRemoveResponse> RemoveFuncion(int FuncionId)
        {
            Funcion? Funcion = await FuncionQuery.GetFuncionById(FuncionId);
            if (Funcion == null)
            {
                throw new NotFoundExcepcion("No se encontro la funcion a eliminar.");
            }
            Funcion = await FuncionCommand.RemoveFuncion(FuncionId);
            if (Funcion == null)
            {
                throw new ConflicExcepcion("No se puede eliminar la funcion debido a que tiene entradas vendidas.");
            }
            FuncionRemoveResponse FuncionRemoveResponse = new FuncionRemoveResponse
            {
                FuncionId = Funcion.FuncionId,
                Fecha = Funcion.Fecha,
                Horario = Funcion.Horario.ToString(@"hh\:mm"),
            };
            return FuncionRemoveResponse;
        }

    }
}
