using Shared.Abstractions;

namespace Domain.Entities
{
    public class Endereco : BaseEntity
    {
        public Endereco(Usuario usuarioId, Guid cidadeId, string rua, string bairro, string complemento, string cep)
        {
            Usuario = usuarioId;
            CidadeId = cidadeId;
            Rua = rua;
            Bairro = bairro;
            Complemento = complemento;
            Cep = cep;
        }

        private Endereco() // ORM
        {
        }

        public Guid UsuarioId { get; set; }
        public Guid CidadeId { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }

        /* EF Relations */
        public Usuario Usuario { get; set; }
        public Cidade Cidade { get; set; }
    }
}