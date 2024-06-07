namespace Domain.Dto
{
    public class EmpresaDto
    {
        public Guid Id { get; set; }
        public string Cnpj { get; private init; }
        public string RazaoSocial { get; private init; }
        public string NomeFantasia { get; private init; }
    }
}
