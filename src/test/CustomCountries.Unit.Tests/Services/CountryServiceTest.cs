using AutoMapper;
using CustomCountries.Application.Services;
using CustomCountries.Application.ViewModels;
using CustomCountries.Domain.Interfaces.Notifications;
using CustomCountries.Domain.Interfaces.Repositories;
using CustomCountries.Domain.Models.Country;
using CustomCountries.Unit.Tests.Mock;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace CustomCountries.Unit.Tests.Services
{
    public class CountryServiceTest
    {
        private readonly Mock<ICountryRepository> _countryRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IDomainNotification> _domainNotificationMock;

        public CountryServiceTest()
        {
            _countryRepositoryMock = new Mock<ICountryRepository>();
            _mapperMock = new Mock<IMapper>();
            _domainNotificationMock = new Mock<IDomainNotification>();
        }

        [Fact]
        public async Task GetAllCountries_ShouldReturnModelsTest()
        {
            var countriesFaker = CountryMock.CountryFaker.Generate(10);
            _countryRepositoryMock.Setup(c => c.FilterByAsync(It.IsAny<Expression<Func<Country, bool>>>())).ReturnsAsync(countriesFaker);
            _mapperMock.Setup(m => m.Map<IEnumerable<CountryViewModel>>(It.IsAny<object>())).Returns(CountryMock.CountryViewModelFaker.Generate(10));

            var countryService = new CountryService(_countryRepositoryMock.Object, _mapperMock.Object, _domainNotificationMock.Object);
            var result = await countryService.GetAllCountries();

            Assert.NotNull(result);
            Assert.True(result.Any() && result.Count() == 10);
        }

        [Fact]
        public async Task InsertOrUpdateCountry_ShouldNotifyValidationTest()
        {
            var countryViewModelFaker = CountryMock.CountryViewModelFaker.Generate();
            var countryFaker = CountryMock.CountryFaker.Generate();
            countryFaker.Name = string.Empty;
            var domainNotification = new DomainNotification();

            _mapperMock.Setup(m => m.Map<Country>(It.IsAny<object>())).Returns(countryFaker);
            var countryService = new CountryService(_countryRepositoryMock.Object, _mapperMock.Object, domainNotification);
            var result = await countryService.InsertOrUpdateCountry(countryViewModelFaker);

            var notifications = domainNotification.Notifications.ToList();

            Assert.Contains(notifications, c => c.Value == "Name must not be empty!");
        }
    }
}
