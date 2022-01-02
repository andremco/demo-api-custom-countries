using Demo.CustomCountries.Domain.Models.Country;

namespace Demo.CustomCountries.Domain.Interfaces.Repositories
{
    public interface ICountryRepository : IMongoRepository<Country>
    {
    }
}
