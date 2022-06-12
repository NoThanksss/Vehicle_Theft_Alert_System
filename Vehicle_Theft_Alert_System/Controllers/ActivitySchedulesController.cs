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
    public class ActivitySchedulesController : Controller
    {
        private IActivityScheduleService _activityScheduleService;
        private ILogger<ActivitySchedulesController> _logger;
        public ActivitySchedulesController(IActivityScheduleService activityScheduleService, ILogger<ActivitySchedulesController> logger)
        {
            _activityScheduleService = activityScheduleService;
            _logger = logger;

        }

        [HttpPost]
        public async Task<IActionResult> AddNewActivitySchedule([FromBody] ActivitySchedule activitySchedule)
        {
            try 
            { 
                var result = _activityScheduleService.AddNewActivitySchedule(activitySchedule);

                return Ok(result);
            }
            catch (ActivityScheduleServiceException ex)
            {
                _logger.LogError(ex, "Exception in AddNewActivitySchedule method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in AddNewActivitySchedule method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateActivitySchedule([FromBody] ActivitySchedule activitySchedule)
        {
            try 
            { 
            var result = _activityScheduleService.UpdateActivitySchedule(activitySchedule);

            return Ok(result);
            }
            catch (ActivityScheduleServiceException ex)
            {
                _logger.LogError(ex, "Exception in UpdateActivitySchedule method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in UpdateActivitySchedule method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivitySchedule(Guid id)
        {
            try 
            { 
                _activityScheduleService.DeleteActivitySchedule(id);

                return Ok("Country was deleted");
            }
            catch (ActivityScheduleServiceException ex)
            {
                _logger.LogError(ex, "Exception in DeleteActivitySchedule method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in DeleteActivitySchedule method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAlActivitySchedules()
        {
            try 
            { 
                var result = _activityScheduleService.GetAllActivitySchedules();

                return Ok(result);
            }
            catch (ActivityScheduleServiceException ex)
            {
                _logger.LogError(ex, "Exception in GetAlActivitySchedules method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in GetAlActivitySchedules method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivityScheduleById(Guid id)
        {
            try 
            { 
                var result = _activityScheduleService.GetActivityScheduleById(id);

                return Ok(result);
            }
            catch (ActivityScheduleServiceException ex)
            {
                _logger.LogError(ex, "Exception in GetActivityScheduleById method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in GetActivityScheduleById method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
