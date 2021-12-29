using CustomCountries.Domain.Models.Country;

namespace CustomCountries.Domain.Interfaces.Repositories
{
    public interface ICountryRepository : IMongoRepository<Country>
    {
    }
}
