using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteJra2w.Models
{
    public class Clientes
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Enderecos> Enderecos { get; set; }


    }
}
