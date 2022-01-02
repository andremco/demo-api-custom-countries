using Bogus;
using Demo.CustomCountries.Application.ViewModels;
using Demo.CustomCountries.Domain.Models.Country;
using System.Collections.Generic;

namespace Demo.CustomCountries.Unit.Tests.Mock
{
    public class CountryMock
    {
        public static Faker<CountryViewModel> CountryViewModelFaker =>
            new Faker<CountryViewModel>()
                .CustomInstantiator(x => new CountryViewModel { 
                    Id = x.Random.String(),
                    Name = x.Address.Country(),
                    Native = x.Address.Country(),
                    Capital = x.Address.State(),
                    Emoji = x.Random.String(),
                    Currency = x.Finance.Currency().Description,
                    Languages = new List<LanguageViewModel>()
                    {
                        new LanguageViewModel(){ 
                           Code = x.Address.CountryCode(),
                           Name = x.Address.Country()
                        },
                        new LanguageViewModel(){
                           Code = x.Address.CountryCode(),
                           Name = x.Address.Country()
                        },
                        new LanguageViewModel(){
                           Code = x.Address.CountryCode(),
                           Name = x.Address.Country()
                        }
                    }
                });

        public static Faker<Country> CountryFaker =>
            new Faker<Country>()
                .CustomInstantiator(x => new Country
                {
                    Name = x.Address.Country(),
                    Native = x.Address.Country(),
                    Capital = x.Address.State(),
                    Emoji = x.Random.String(),
                    Currency = x.Finance.Currency().Description,
                    Languages = new List<Language>()
                    {
                        new Language(){
                           Code = x.Address.CountryCode(),
                           Name = x.Address.Country()
                        },
                        new Language(){
                           Code = x.Address.CountryCode(),
                           Name = x.Address.Country()
                        },
                        new Language(){
                           Code = x.Address.CountryCode(),
                           Name = x.Address.Country()
                        }
                    }
                });
    }
}
