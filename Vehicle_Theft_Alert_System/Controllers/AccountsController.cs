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
    public class AccountsController : Controller
    {
        private IAccountService _accountService;
        private ILogger<AccountsController> _logger;
        public AccountsController(IAccountService accountService, ILogger<AccountsController> logger)
        {
            _accountService = accountService;
            _logger = logger;

        }

        [HttpGet("Family/{familyId}")]
        public async Task<IActionResult> GetAllFamilyAccounts(Guid familyId)
        {
            try
            {
                return Ok(_accountService.GetAllFamilyAcounts(familyId));
            }
            catch (AccountServiceException ex)
            {
                _logger.LogError(ex, "Exception in GetAllFamilyAccounts method");
                return BadRequest(ex.Message);
            }
            catch(Exception ex) 
            {
                _logger.LogCritical(ex, "Exception in GetAllFamilyAccounts method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("Balance/{accountId}")]
        public async Task<IActionResult> UpdateBalance(Guid accountId, [FromQuery] decimal amount)
        {
            try
            { 
                var result = await _accountService.UpdateBalance(accountId, amount);
                return Ok("Balance was updated");
            }
            catch (AccountServiceException ex)
            {
                _logger.LogError(ex, "Exception in UpdateBalance method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in UpdateBalance method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddNewAccount([FromBody] Account country)
        {
            try 
            { 
                var result = _accountService.AddNewAccount(country);

                return Ok(result);
            }
            catch (AccountServiceException ex)
            {
                _logger.LogError(ex, "Exception in AddNewAccount method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in AddNewAccount method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAccount([FromBody] Account country)
        {
            try 
            { 
                var result = _accountService.UpdateAccount(country);

                return Ok(result);
            }
            catch (AccountServiceException ex)
            {
                _logger.LogError(ex, "Exception in UpdateAccount method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in UpdateAccount method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(Guid id)
        {
            try 
            { 
                _accountService.DeleteAccount(id);

                return Ok("Account was deleted");
            }
            catch (AccountServiceException ex)
            {
                _logger.LogError(ex, "Exception in DeleteAccount method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in DeleteAccount method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            try 
            { 
                var result = _accountService.GetAllAccounts();

                return Ok(result);
            }
            catch (AccountServiceException ex)
            {
                _logger.LogError(ex, "Exception in GetAllAccounts method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in GetAllAccounts method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountById(Guid id)
        {
            try 
            { 
                var result = await _accountService.GetAccountByIdAsync(id);

                return Ok(result);
            }
            catch (AccountServiceException ex)
            {
                _logger.LogError(ex, "Exception in GetAccountById method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in GetAccountById method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
