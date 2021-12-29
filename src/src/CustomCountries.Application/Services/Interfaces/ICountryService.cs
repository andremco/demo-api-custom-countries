using CustomCountries.Application.ViewModels;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomCountries.Application.Services.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryViewModel>> GetAllCountries();
        Task<CountryViewModel> InsertOrUpdateCountry(CountryViewModel countryViewModel);
    }
}
