using Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Endereco : BaseEntity
    {
        public Guid EnderecoId { get; set; }
        public string Rua { get; set; }
        public Cidade Cidade { get; set; }
        public string CidadeId { get; set; }
        public string Cep { get; set; }

        public Usuario Usuario { get; set; }
    }
}
