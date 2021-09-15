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
        
        //Rota exemplo http://localhost:59662/api/Clientes

        [HttpGet]
        public ActionResult Get()
        {
            var listCliente = _context.Cliente
                .Include(p => p.Enderecos)
                .ToList();
            return Ok(listCliente);
        }


        // GET ById

        //Rota Exemplo http://localhost:59662/buscar/73

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

        // Rota Exemplo http://localhost:59662/adicionar

        [HttpPost("/adicionar")]
        public void Postnome([FromBody] Clientes cliente)
        {
            _context.Cliente.Add(cliente);
            _context.SaveChanges();
        }



        //Update

        //Rota Exemplo http://localhost:59662/atualizar?id=73


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


        // DELETAR

        // Rota Exemplo http://localhost:59662/delete?id=73

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
