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

        [HttpGet("ObterTodosNomes")]
        public IActionResult GetAllName()
        {
            var contatosNome = _context.Contatos.Select(x => x.Name).ToList();
           

            return Ok(contatosNome);
        }

        [HttpGet("ObterTodosContatos")]
        public IActionResult GetAllContatcts()
        {
            var contato = _context.Contatos.ToList();

            return Ok(contato);
        }

        //Obter por id
        [HttpGet("{id}")]
        public IActionResult GetPerId(int id)
        {
            var contato = _context.Contatos.Find(id);
            return contato == null ? NotFound() : Ok(contato);
        }

        //Obter por nome
        [HttpGet("ObterPorNome")]
        public IActionResult GetPerName(string name)
        {
            var contato = _context.Contatos.Where(x => x.Name.Contains(name));
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

        [HttpPut("{id}")]
        public IActionResult UpdatePerId (int id, Contatos contato) 
        {
            var contatoBanco = _context.Contatos.Find(id);
            if(contatoBanco == null)
            {
                return NotFound();
            }

            contatoBanco.Name = contato.Name;
            contatoBanco.Phone = contato.Phone;
            contatoBanco.Active = contato.Active;

            _context.Update(contatoBanco);
            _context.SaveChanges();

            return Ok(contatoBanco);

        }
    }
}



