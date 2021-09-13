using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TesteJR.Dominio;
using TesteJR.Repositorio;



namespace TesteJR_A2W.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        //Construtor ClienteContext _context

        public readonly ClientesContext _context;
        public ClientesController(ClientesContext context)
        {
            _context = context;
        }
        
        //Fim Construtor


        // GET ALL

        [HttpGet]
        public ActionResult Get()
        {
            var listCliente = _context.Cliente.ToList();
            return Ok(listCliente);
        }


        // GET ById

        [HttpGet("/buscar/{id:int}")]
        public ActionResult GetId(int id)
        {
            var result = _context.Cliente.Find(id);
            if (result == null) return NotFound();
            return Ok(result);
        }


        // Post Adicionar Cliente

        [HttpPost("/adicionar")]
        public void Postnome([FromBody] string nome, string endereco)
        {
            var clientes = new Clientes { Nome = nome };
            var clientes_endereco = new Enderecos { Endereco = endereco };
            _context.Cliente.Add(clientes);
            _context.SaveChanges();
        }


        // POST adicionar endereco

        [HttpPost("/adicionarendereco")]
        public void Post([FromBody] string endereco)
        {
            {
                var clientes_endereco = new Enderecos { Endereco = endereco};
                _context.Endereco.Add(clientes_endereco);
                _context.SaveChanges();
            }
        }


        // PUT api/<ClientesController>/5

        [HttpPut("/atualizar")]
        public void Put(int id, [FromBody] string value)
        {
            var clienteid = _context.Cliente.Find(id);
            clienteid.Nome = value;
            _context.SaveChanges();
        }

        // DELETE api/<ClientesController>/5

        [HttpDelete("/delete")]
        public void Delete(int id)
        {
            var clientedel = _context.Cliente.Find(id);
            _context.Cliente.Remove(clientedel);
            _context.SaveChanges();

        }
    }
}
