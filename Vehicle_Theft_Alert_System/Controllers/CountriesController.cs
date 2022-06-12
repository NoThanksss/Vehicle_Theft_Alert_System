using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Vehicle_Theft_Alert_System_BLL.Exceptions;
using Vehicle_Theft_Alert_System_BLL.Interfaces;
using Vehicle_Theft_Alert_System_BLL.Models;

namespace Vehicle_Theft_Alert_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CountriesController : Controller
    {
        private ICountryService _countryService;
        private readonly ILogger<CountriesController> _logger;
        public CountriesController(ICountryService countryService, ILogger<CountriesController> logger)
        {
            _countryService = countryService;
            _logger = logger;

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddNewCountry([FromBody] Country country)
        {
            try 
            { 
                var result = _countryService.AddNewCountry(country);

                return Ok(result);
            }
            catch (CountryServiceException ex)
            {
                _logger.LogError(ex, "Exception in AddNewCountry method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in AddNewCountry method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCountry([FromBody] Country country)
        {
            try 
            { 
                var result = _countryService.UpdateCountry(country);

                return Ok(result);
            }
            catch (CountryServiceException ex)
            {
                _logger.LogError(ex, "Exception in UpdateCountry method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in UpdateCountry method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCountry(Guid id)
        {
            try 
            { 
                _countryService.DeleteCountry(id);

                return Ok("Country was deleted");
            }
            catch (CountryServiceException ex)
            {
                _logger.LogError(ex, "Exception in DeleteCountry method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in DeleteCountry method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCountries()
        {
            try 
            { 
                var result = _countryService.GetAllCountrys();

                return Ok(result);
            }
            catch (CountryServiceException ex)
            {
                _logger.LogError(ex, "Exception in GetAllCountries method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in GetAllCountries method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountryById(Guid id)
        {
            try
            {
                var result = _countryService.GetCountryById(id);

                return Ok(result);
            }
            catch (CountryServiceException ex)
            {
                _logger.LogError(ex, "Exception in GetCountryById method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in GetCountryById method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
