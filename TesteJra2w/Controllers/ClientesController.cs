using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var listCliente = _context.Cliente
                .Include(p => p.Enderecos)
                .ToList();
            return Ok(listCliente);
        }


        // GET ById

        [HttpGet("/buscar/{id:int}")]
        public ActionResult GetId(int id)
        {
            var result = _context.Cliente
                .Include(p => p.Enderecos)
                .FirstOrDefault(c => c.Id == id);
            if (result == null) return NotFound();
            return Ok(result);
        }


        // Post Adicionar Cliente

        [HttpPost("/adicionar")]
        public void Postnome([FromBody] Clientes cliente)
        {
            _context.Cliente.Add(cliente);
            _context.SaveChanges();
        }


        // POST adicionar endereco

        //[HttpPost("/adicionarendereco")]
        //public void Post([FromBody] string endereco)
        //{
        //    {
        //        var clientes_endereco = new Enderecos { Endereco = endereco};
        //        _context.Endereco.Add(clientes_endereco);
        //        _context.SaveChanges();
        //    }
        //}


        // PUT api/<ClientesController>/5

        [HttpPut("/atualizar")]
        public void Put(int id, [FromBody] Clientes value)
        {
            var clienteid = _context.Cliente
                .Include(p => p.Enderecos)
                .FirstOrDefault(c => c.Id == id);

           

            foreach (var item in value.Enderecos)
            {
               var endereco = clienteid.Enderecos.Where(c => c.Id == item.Id).FirstOrDefault();
                endereco.cep = item.cep;
                endereco.Endereco = item.Endereco;


            }

            clienteid.Nome = value.Nome;
            _context.SaveChanges();
        }

        // DELETE api/<ClientesController>/5

        [HttpDelete("/delete")]
        public void Delete(int id)
        {
            var clientedel = _context.Cliente
                .Include(c => c.Enderecos)
                .FirstOrDefault(c => c.Id == id);
            _context.Cliente.Remove(clientedel);
            _context.SaveChanges();

        }
    }
}
