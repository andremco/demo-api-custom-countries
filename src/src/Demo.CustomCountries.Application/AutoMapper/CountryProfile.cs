using AutoMapper;
using Demo.CustomCountries.Application.ViewModels;
using Demo.CustomCountries.Domain.Models.Country;

namespace Demo.CustomCountries.Application.AutoMapper
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
