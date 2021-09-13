using Microsoft.EntityFrameworkCore;
using TesteJR.Dominio;



namespace TesteJR.Repositorio
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
            optionsBuilder.UseSqlServer("Password=sa123456;Persist Security Info=True;User ID=sa;Initial Catalog=TesteJR;Data Source=DESKTOP-EAL099F\\TESTEJR");

        }
    }
}
