using Demo.CustomCountries.Domain.Interfaces.Mongo;
using Demo.CustomCountries.Domain.Interfaces.Repositories;
using Demo.CustomCountries.Domain.Models.Country;
using MongoDB.Driver;

namespace Demo.CustomCountries.Data.Repositories
{
    public class CountryRepository :  MongoRepository<Country>, ICountryRepository
    {
        public CountryRepository(IMongoClient mongoClient, string dataBaseName) : base(mongoClient, dataBaseName)
        {
        }
    }
}
