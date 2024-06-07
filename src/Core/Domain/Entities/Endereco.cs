using Shared.Abstractions;

namespace Domain.Entities
{
    public class Endereco : BaseEntity
    {
        public Endereco(Guid cidadeId, string rua, string bairro, string cep, string complemento, int numero)
        {
            CidadeId = cidadeId;
            Rua = rua;
            Bairro = bairro;
            Cep = cep;
            Complemento = complemento;
            Numero = numero;
        }

        public Endereco() { }

        public Guid CidadeId { get; private init; }
        public string Rua { get; private init; }
        public string Bairro { get; private init; }
        public string Cep { get; private init; }
        public string Complemento { get; private init; }
        public int Numero { get; private init; }

        //Relaçao do EF
        public Usuario Usuario { get; private init; }
        public Cidade Cidade { get; private init; }
    }
}