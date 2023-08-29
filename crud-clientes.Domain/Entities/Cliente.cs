using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_clientes.Domain.Entities
{
    public class Cliente
    {
        public Guid ClienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public IEnumerable<Logradouro> Logradouros { get; set; }
    }
}
