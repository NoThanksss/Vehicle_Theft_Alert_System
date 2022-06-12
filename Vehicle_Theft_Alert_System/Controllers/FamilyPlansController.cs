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
    public class FamilyPlansController : Controller
    {
        private IFamilyPlanService _familyPlanService;
        private readonly ILogger<FamilyPlansController> _logger;
        public FamilyPlansController(IFamilyPlanService familyPlanService, ILogger<FamilyPlansController> logger)
        {
            _familyPlanService = familyPlanService;
            _logger = logger;

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddNewFamilyPlan([FromBody] FamilyPlan country)
        {
            try 
            { 
                var result = _familyPlanService.AddNewFamilyPlan(country);

                return Ok(result);
            }
            catch (FamilyPlanServiceException ex)
            {
                _logger.LogError(ex, "Exception in AddNewFamilyPlan method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in AddNewFamilyPlan method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateFamilyPlan([FromBody] FamilyPlan country)
        {
            try 
            { 
                var result = _familyPlanService.UpdateFamilyPlan(country);

                return Ok(result);
            }
            catch (FamilyPlanServiceException ex)
            {
                _logger.LogError(ex, "Exception in UpdateFamilyPlan method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in UpdateFamilyPlan method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteFamilyPlan(Guid id)
        {
            try 
            { 
                _familyPlanService.DeleteFamilyPlan(id);

                return Ok("FamilyPlan was deleted");
            }
            catch (FamilyPlanServiceException ex)
            {
                _logger.LogError(ex, "Exception in DeleteFamilyPlan method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in DeleteFamilyPlan method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFamilyPlans()
        {
            try 
            { 
                var result = _familyPlanService.GetAllFamilyPlans();

                return Ok(result);
            }
            catch (FamilyPlanServiceException ex)
            {
                _logger.LogError(ex, "Exception in GetAllFamilyPlans method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in GetAllFamilyPlans method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFamilyPlanById(Guid id)
        {
            try 
            { 
                var result = _familyPlanService.GetFamilyPlanById(id);

                return Ok(result);
            }
            catch (FamilyPlanServiceException ex)
            {
                _logger.LogError(ex, "Exception in GetFamilyPlanById method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in GetFamilyPlanById method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
