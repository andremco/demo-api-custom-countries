using AutoMapper;
using CustomCountries.Application.ViewModels;
using CustomCountries.Domain.Models.Country;

namespace CustomCountries.Application.AutoMapper
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryViewModel>()
                .ForMember(s => s.Id, d => d.MapFrom(d => d.Id.ToString()));

            CreateMap<CountryViewModel, Country>()
                .ForMember(s => s.Id, d => d.Ignore())
                .ForMember(s => s.CreatedAt, d => d.Ignore());

            CreateMap<LanguageViewModel, Language>().ReverseMap();
        }
    }
}
