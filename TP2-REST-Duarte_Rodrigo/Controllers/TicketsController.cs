using Application.Interface.Funciones;
using Application.Interface.Tickets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TP2_REST_Duarte_Rodrigo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _service;

        public TicketsController(ITicketService service)
        {
            _service = service;
        }

        [HttpPost("ticket")]
        public async Task<IActionResult> AddTicket (string usuario, int funcionID)
        {
            bool resultado = await _service.AddTicket(usuario, funcionID);
            if (resultado)
            {
                return Ok("Ticket obtenido exitosamente");
            }
            return BadRequest("Ha habido un problema");
        }
    }
}
