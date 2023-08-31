using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_clientes.Domain.Entities
{
    public class Logradouro
    {
        public Guid LogradouroId { get; set; } 
        public Guid ClienteId { get; set; }
        public string Cep { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string UF { get; set; } = string.Empty;
    }
}
