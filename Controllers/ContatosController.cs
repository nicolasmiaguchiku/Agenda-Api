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

        //Obter por id
        [HttpGet("{id}")]
        public IActionResult GetPerId(int id)
        {
            var contato = _context.Contatos.Find(id);
            return contato == null ? NotFound() : Ok(contato);
        }

        // Delete
        [HttpDelete("{id}")]
        public IActionResult DeletePerId(int id)
        {
            var contato = _context.Contatos.Find(id);
            if(contato == null)
            {
                return NotFound();
            }

            _context.Remove(contato);
            _context.SaveChanges();

            return Ok(contato);
        }
    }
}



