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
        public Guid UsuarioId { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public Cidade Cidade { get; set; }
        public Guid CidadeId { get; set; }
        public string Cep { get; set; }

        /* EF Relations */
        public Usuario Usuario { get; set; }
    }
}
