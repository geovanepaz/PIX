using AutoMapper;
using Pix.Application.ViewModels.Cliente;
using Pix.Domain;

namespace Pix.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cliente, ClienteResponse>();
        }
    }
}
