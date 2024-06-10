using Domain.Entities;
using Shared.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.UsuarioRequests
{
    public class UsuarioRequests : BaseRequestWithValidation
    {
        public string Nome { get; set; }
        public int Cpf { get; set; }
        public string NomeDaMae { get; set; }
        public string NomeDoPai { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public EnderecoRequests Endereco { get; set; }

    }
}
