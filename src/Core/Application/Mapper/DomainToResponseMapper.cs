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
        }
    }
}
