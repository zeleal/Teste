using AutoMapper;
using Domain.Dto;
using Domain.Entities;

namespace Application.Mapper
{
    public class DomainToResponseMapper : Profile
    {
        public DomainToResponseMapper()
        {
            CreateMap<Cidade, CidadeDto>(MemberList.Destination);
            CreateMap<Estado, EstadoDto>(MemberList.Destination);
            CreateMap<Regiao, RegiaoDto>(MemberList.Destination);
            CreateMap<Usuario, UsuarioDto>(MemberList.Destination).ReverseMap();
            CreateMap<UsuarioEmpresa, UsuarioEmpresaDto>(MemberList.Destination).ReverseMap();
            CreateMap<Endereco, EnderecoDto>(MemberList.Destination).ReverseMap();
            CreateMap<Empresa, EmpresaDto>(MemberList.Destination).ReverseMap();
        }
    }
}
