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

            //CreateMap<UsuarioDto, Usuario>(MemberList.Destination);
            //CreateMap<UsuarioEmpresaDto, UsuarioEmpresa>(MemberList.Destination);
            //CreateMap<EnderecoDto, Endereco>(MemberList.Destination);
            //CreateMap<EmpresaDto, Empresa>(MemberList.Destination);
        }
    }
}
