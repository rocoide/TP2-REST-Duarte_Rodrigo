using Application.Interface.Funciones;
using Application.Model.Response;
using Domain.Entity;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Command
{
    public class FuncionCommand : IFuncionCommand
    {
        private readonly CineContext _context;

        public FuncionCommand(CineContext context)
        {
            _context = context;
        }
        public async Task<FuncionResponse> AddFuncion(Funcion fun)
        {
            TimeSpan tiempo_agregado = new TimeSpan(2, 30, 0);
            TimeSpan aux = fun.Horario + TimeSpan.FromHours(-2) + TimeSpan.FromMinutes(-30); //auxiliar para simular la comparacion con el fin de las peliculas en cartelera
            TimeSpan hora_fin = fun.Horario.Add(tiempo_agregado);
            Funcion? funcion_solapada = _context.Funciones
                                                .FirstOrDefault(f => (f.SalaId == fun.SalaId) &&
                                                          (f.Fecha.Month == fun.Fecha.Month) &&
                                                          (f.Fecha.Day == fun.Fecha.Day) &&
                                                          (
                                                            (f.Horario >= fun.Horario && f.Horario < hora_fin) ||
                                                            (f.Horario <= fun.Horario && f.Horario > aux)
                                                          )
                                                );
            if (funcion_solapada == null)
            {
                _context.Funciones.Add(fun);
                _context.SaveChanges();
                Funcion? fun2 = await _context.Funciones
                                              .Include(s => s.Peliculas)
                                                .ThenInclude(f => f.Generos)
                                              .Include(m => m.Salas)
                                              .FirstOrDefaultAsync(s => s.FuncionId == fun.FuncionId);
                FuncionResponse funcionResponse = new FuncionResponse
                {
                    funcionId = fun2.FuncionId,
                    pelicula = new PeliculaResponseShort
                    {
                        peliculaId = fun2.PeliculaId,
                        titulo = fun2.Peliculas.Titulo,
                        poster = fun2.Peliculas.Poster,
                        genero = new GeneroResponse
                        {
                            id = fun2.Peliculas.Generos.GeneroId,
                            nombre = fun2.Peliculas.Generos.Nombre
                        }
                    },
                    sala = new SalaResponse
                    {
                        id = fun2.Salas.SalaId,
                        nombre = fun2.Salas.Nombre,
                        capacidad = fun2.Salas.Capacidad
                    },
                    fecha = fun2.Fecha,
                    horario = fun2.Horario.ToString(@"hh\:mm")
                };
                return funcionResponse;
            }
            else
            {
                return null;
            }
        }

        public async Task<FuncionRemoveResponse?> removeFuncion(int funcionID)
        {
            Funcion? funcion = await _context.Funciones.FindAsync(funcionID);
            List<Ticket> lista_tickets = await _context.Tickets
                                                       .Where(s => s.FuncionId == funcionID)
                                                       .ToListAsync();
            if ((funcion != null) && (lista_tickets.Count == 0))
            {
                _context.Funciones.Remove(funcion);
                _context.SaveChanges();
                FuncionRemoveResponse funcion_removida = new FuncionRemoveResponse
                {
                    funcionId = 0,
                    fecha = funcion.Fecha,
                    horario = funcion.Horario.ToString(@"hh\:mm")
                };
                return funcion_removida;
            }
            else
            {
                if (funcion == null)
                {
                    return null;
                }
                else
                {
                    FuncionRemoveResponse funcion_removida = new FuncionRemoveResponse
                    {
                        funcionId = -1
                    };
                    return funcion_removida;
                }
            }
        }
    }
}
