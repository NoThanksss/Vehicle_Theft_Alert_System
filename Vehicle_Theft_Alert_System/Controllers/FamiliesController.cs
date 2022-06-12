using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Vehicle_Theft_Alert_System_BLL.Exceptions;
using Vehicle_Theft_Alert_System_BLL.Interfaces;
using Vehicle_Theft_Alert_System_BLL.Models;

namespace Vehicle_Theft_Alert_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class FamiliesController : Controller
    {
        private IFamilyService _familyService;
        private IAccountService _accountService;
        private IFamilyPlanService _familyPlanService;
        private readonly ILogger<FamiliesController> _logger;
        public FamiliesController(IFamilyService familyService, IAccountService accountService,
            IFamilyPlanService familyPlanService, ILogger<FamiliesController> logger)
        {
            _familyService = familyService;
            _accountService = accountService;
            _familyPlanService = familyPlanService;
            _logger = logger;

        }

        [HttpPut("AddAccount/{familyId}")]
        public async Task<IActionResult> AddAccountToFamily(Guid familyId, [FromQuery]Guid accountId)
        {
            try 
            { 
                var accountToAdd = _accountService.GetAccountById(accountId);
                var family = _familyService.GetFamilyById(familyId);       

                if (family.FamilyPlanId == null)
                {
                    accountToAdd.FamilyId = family.Id;
                    return Ok(_accountService.UpdateAccount(accountToAdd));
                }
                var familyPlan = _familyPlanService.GetFamilyPlanById((Guid)family.FamilyPlanId);

                var familiesWithPlanCount = _accountService.GetAllAccounts().Where(x => x.FamilyId == family.Id).Count();
                if (familiesWithPlanCount >= familyPlan.MaxMemberNumber)
                {
                    return BadRequest($"{familyPlan.Name} max members count is {familyPlan.MaxMemberNumber}");
                }
                accountToAdd.FamilyId = family.Id;
                return Ok(_accountService.UpdateAccount(accountToAdd));
            }
            catch (AccountServiceException ex)
            {
                _logger.LogError(ex, "Exception in AddAccountToFamily method");
                return BadRequest(ex.Message);
            }
            catch (FamilyServiceException ex)
            {
                _logger.LogError(ex, "Exception in AddAccountToFamily method");
                return BadRequest(ex.Message);
            }
            catch (FamilyPlanServiceException ex)
            {
                _logger.LogError(ex, "Exception in AddAccountToFamily method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in AddAccountToFamily method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("WithdrawBalance/{familyId}")]
        public async Task<IActionResult> WithdrawBalance(Guid familyId, [FromQuery] decimal amount)
        {
            try 
            { 
                var family = _familyService.GetFamilyById(familyId);
                var accounts = _accountService.GetAllAccounts().Where(x => x.FamilyId == family.Id).ToList();//.First(x => x.BillAmount >= amount);

                if (family.FamilyPlanId == null) 
                {
                    var account = accounts.FirstOrDefault(x => x.BillAmount >= amount);
                    if (account == null)
                    {
                        return BadRequest($"None of {family.Name} accounts has enough money.");
                    }

                    await _accountService.UpdateBalance(account.Id, -amount);
                    return Ok("Family balance was updated.");
                }

                var familyPlan = _familyPlanService.GetFamilyPlanById((Guid)family.FamilyPlanId);
                var amountWithDiscount = amount - amount * familyPlan.Discount/100;
                var accountWithDiscount = accounts.FirstOrDefault(x => x.BillAmount >= amountWithDiscount);
                if (accountWithDiscount == null)
                {
                    return BadRequest($"None of {family.Name} accounts has enough money.");
                }

                await _accountService.UpdateBalance(accountWithDiscount.Id, -amountWithDiscount);
                return Ok("Family balance was updated.");
            }
            catch (AccountServiceException ex)
            {
                _logger.LogError(ex, "Exception in WithdrawBalance method");
                return BadRequest(ex.Message);
            }
            catch (FamilyServiceException ex)
            {
                _logger.LogError(ex, "Exception in WithdrawBalance method");
                return BadRequest(ex.Message);
            }
            catch (FamilyPlanServiceException ex)
            {
                _logger.LogError(ex, "Exception in WithdrawBalance method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in WithdrawBalance method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewFamily([FromBody] Family country)
        {
            try 
            { 
                var result = _familyService.AddNewFamily(country);

                return Ok(result);
            }
            catch (FamilyServiceException ex)
            {
                _logger.LogError(ex, "Exception in AddNewFamily method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in AddNewFamily method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFamily([FromBody] Family country)
        {
            try 
            { 
                var result = _familyService.UpdateFamily(country);

                return Ok(result);
            }
            catch (FamilyServiceException ex)
            {
                _logger.LogError(ex, "Exception in UpdateFamily method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in UpdateFamily method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFamily(Guid id)
        {
            try 
            { 
                _familyService.DeleteFamily(id);

                return Ok("Family was deleted");
            }
            catch (FamilyServiceException ex)
            {
                _logger.LogError(ex, "Exception in DeleteFamily method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in DeleteFamily method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllFamilies()
        {
            try 
            { 
                var result = _familyService.GetAllFamilies();

                return Ok(result);
            }
            catch (FamilyServiceException ex)
            {
                _logger.LogError(ex, "Exception in GetAllFamilies method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in GetAllFamilies method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFamilyById(Guid id)
        {
            try 
            { 
                var result = _familyService.GetFamilyById(id);

                return Ok(result);
            }
            catch (FamilyServiceException ex)
            {
                _logger.LogError(ex, "Exception in GetFamilyById method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in GetFamilyById method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
