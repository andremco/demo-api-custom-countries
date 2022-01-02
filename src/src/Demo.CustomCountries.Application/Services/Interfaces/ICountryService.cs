using Demo.CustomCountries.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.CustomCountries.Application.Services.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryViewModel>> GetAllCountries();
        Task<CountryViewModel> InsertOrUpdateCountry(CountryViewModel countryViewModel);
    }
}
