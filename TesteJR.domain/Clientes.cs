using System.Collections.Generic;

namespace TesteJR.Dominio

{
    public class Clientes
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Enderecos> Enderecos { get; set; }


    }
}