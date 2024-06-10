namespace Domain.Dto
{
    public class EmpresaDto
    {
        public Guid Id { get; private init; }
        public string NomeFantasia { get; private init; }
        public string RazaoSocial { get; private init; }
        public string CNPJ { get; private init; }
    }
}