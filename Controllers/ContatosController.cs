using Microsoft.AspNetCore.Mvc;
using AgendaApi.Contexts;
using AgendaApi.Entities;

namespace AgendaApi.Controllers
{
    [ApiController]
    [Route("Controller")]

    public class ContatosController : ControllerBase
    {
        private readonly AgendaContext? _context;

        public ContatosController(AgendaContext context)
        {
            _context = context;
        }

        //Add Contact
        [HttpPost]
        public IActionResult AddContact(Contatos contato)
        {
            _context?.Add(contato);
            _context?.SaveChanges();
            return Ok(contato);
        }
        
    }
}
