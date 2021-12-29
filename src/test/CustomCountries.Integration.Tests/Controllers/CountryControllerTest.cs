using CustomCountries.API;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace CustomCountries.Integration.Tests.Controllers
{
    public class CountryControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;

        public CountryControllerTest(WebApplicationFactory<Startup> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task GetAll_HttpStatusCodeUnauthorizedTestAsync()
        {
            var response = await _httpClient.GetAsync("/api/v1/countries");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
