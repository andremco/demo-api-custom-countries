using CustomCountries.Application.Services.Interfaces;
using CustomCountries.Application.ViewModels;
using CustomCountries.Domain.Interfaces.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCountries.API.Controllers.v1
{
    [Authorize]
    [ApiController]
    [Route("api/v1/countries")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly IDomainNotification _domainNotification;

        public CountryController(ICountryService countryService, IDomainNotification domainNotification)
        {
            _countryService = countryService;
            _domainNotification = domainNotification;
        }

        /// <summary>
        /// Get All Custom Countries
        /// </summary>        
        /// <returns>Get All Custom Countries</returns>
        /// <response code="200">Return all custom countries</response>
        /// <response code="404">Not found</response>       
        /// <response code="500">Internal server error</response> 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryViewModel>>> GetAll()
        {
            var countries = await _countryService.GetAllCountries();

            if (countries != null && countries.Any())
            {
                return Ok(countries);
            }

            return NoContent();
        }

        /// <summary>
        /// Insert Or Update Custom Country
        /// </summary>        
        /// <param name="countryViewModel">Request Country</param>
        /// <returns>Custom Country</returns>
        /// <response code="200">Return custom country</response>
        /// <response code="400">Bad request</response>       
        /// <response code="500">Internal server error</response> 
        [HttpPost]
        public async Task<ActionResult<CountryViewModel>> PostCustomCountry([FromBody] CountryViewModel countryViewModel)
        {
            await _countryService.InsertOrUpdateCountry(countryViewModel);

            if (_domainNotification.HasNotifications)
                return new EmptyResult();
            
            return Ok(countryViewModel);
        }
    }
}
