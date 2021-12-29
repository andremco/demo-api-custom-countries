using AutoMapper;
using CustomCountries.Application.AutoMapper;
using Xunit;

namespace CustomCountries.Unit.Tests.Mapper
{
    public class MappingTest
    {
        [Fact]
        public void AutoMapper_Configuration_IsValid()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                // Add all Profiles from the Assembly containing this Type
                cfg.AddMaps(typeof(CountryProfile));
            });

            configuration.AssertConfigurationIsValid();
        }
    }
}
