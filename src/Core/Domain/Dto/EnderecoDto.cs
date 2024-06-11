using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class EnderecoDto
    {
        public Guid Id { get; private init; }
        //public Guid CidadeId { get; private init; }
        //public Guid UsuarioId { get; private init; }
        public string Rua { get; private init; }
        public string Bairro { get; private init; }
        public string Complemento { get; private init; }
        public string Cep { get; private init; }
    }
}