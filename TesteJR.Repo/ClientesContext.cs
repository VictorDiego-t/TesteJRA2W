using Microsoft.EntityFrameworkCore;
using TesteJR.Dominio;



namespace TesteJR.Repo
{
    public class ClientesContext : DbContext
    {

        public ClientesContext()
        {
            
        }

        public DbSet<Clientes> Cliente { get; set; }
        public DbSet<Enderecos> Endereco { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS01;Database=master;Trusted_Connection=True;");

        }
    }
}
