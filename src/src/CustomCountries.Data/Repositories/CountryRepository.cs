using CustomCountries.Domain.Interfaces.Mongo;
using CustomCountries.Domain.Interfaces.Repositories;
using CustomCountries.Domain.Models.Country;
using MongoDB.Driver;

namespace CustomCountries.Data.Repositories
{
    public class CountryRepository :  MongoRepository<Country>, ICountryRepository
    {
        public CountryRepository(IMongoClient mongoClient, string dataBaseName) : base(mongoClient, dataBaseName)
        {
        }
    }
}
