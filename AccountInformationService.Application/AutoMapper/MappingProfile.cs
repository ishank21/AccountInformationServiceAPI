using AccountInformationService.Application.ViewModels;
using AccountInformationService.Core.Entities;
using AutoMapper;

namespace AccountInformationService.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ClientDetails, ClientDetailsViewmodel>();
            CreateMap<AccountDetails, AccountDetailsViewModel>().ForMember(destinationMember:
                desc => desc.IsClosed, opt => opt.MapFrom(src => int.Parse(src.IsClosed)));
        }
    }
}
