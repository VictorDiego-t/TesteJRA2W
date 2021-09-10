using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteJra2w.Models
{
    public class Enderecos
    {
        public int Id { get; set; }

        public string Endereco { get; set; }

        public string cep { get; set; }

        public Clientes Clientes { get; set; }
    }
}
