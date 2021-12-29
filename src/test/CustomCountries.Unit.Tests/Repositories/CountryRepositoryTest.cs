using CustomCountries.Data.Repositories;
using CustomCountries.Domain.Models.Country;
using CustomCountries.Unit.Tests.Mock;
using MongoDB.Driver;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CustomCountries.Unit.Tests.Repositories
{
    public class CountryRepositoryTest
    {
        private readonly Mock<IMongoClient> _mongoClientMock;
        private readonly Mock<IMongoDatabase> _mongoDatabase;
        private readonly Mock<IMongoCollection<Country>> _mongoCollection;

        public CountryRepositoryTest()
        {
            _mongoClientMock = new Mock<IMongoClient>();
            _mongoDatabase = new Mock<IMongoDatabase>();
            _mongoCollection = new Mock<IMongoCollection<Country>>();
        }

        [Fact]
        public async Task FindOneAsync_ShouldInsertTest()
        {
            var countryFaker = CountryMock.CountryFaker.Generate();
            _mongoDatabase.Setup(m => m.GetCollection<Country>(It.IsAny<string>(), null)).Returns(_mongoCollection.Object);
            _mongoClientMock.Setup(m => m.GetDatabase(It.IsAny<string>(), null)).Returns(_mongoDatabase.Object);

            var countryRepository = new CountryRepository(_mongoClientMock.Object, "test");
            await countryRepository.InsertOneAsync(countryFaker);
        }

        [Fact]
        public async Task FindOneAsync_ShouldUpdateTest()
        {
            var countryFaker = CountryMock.CountryFaker.Generate();
            _mongoDatabase.Setup(m => m.GetCollection<Country>(It.IsAny<string>(), null)).Returns(_mongoCollection.Object);
            _mongoClientMock.Setup(m => m.GetDatabase(It.IsAny<string>(), null)).Returns(_mongoDatabase.Object);

            var countryRepository = new CountryRepository(_mongoClientMock.Object, "test");
            await countryRepository.ReplaceOneAsync(countryFaker);
        }

        [Fact]
        public async Task DeleteByIdAsync_ShouldDeleteTest()
        {
            var countryFaker = CountryMock.CountryFaker.Generate();
            _mongoDatabase.Setup(m => m.GetCollection<Country>(It.IsAny<string>(), null)).Returns(_mongoCollection.Object);
            _mongoClientMock.Setup(m => m.GetDatabase(It.IsAny<string>(), null)).Returns(_mongoDatabase.Object);

            var countryRepository = new CountryRepository(_mongoClientMock.Object, "test");
            await countryRepository.DeleteByIdAsync(countryFaker.Id.ToString());
        }
    }
}
