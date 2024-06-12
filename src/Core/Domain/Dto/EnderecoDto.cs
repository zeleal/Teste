using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class EnderecoDto
    {
        public Guid Id { get; set; }
        public Guid CidadeId { get; set; }
        public Guid UsuarioId { get; set; }
        public string Rua { get; private init; }
        public string Bairro { get; private init; }
        public string Complemento { get; private init; }
        public string Cep { get; private init; }
    }
}