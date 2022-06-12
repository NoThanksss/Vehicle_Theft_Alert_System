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
    public class TrackersController : Controller
    {
        private ITrackerService _trackerService;
        private IConnectionService _connectionService;
        private readonly ILogger<TrackersController> _logger;
        public TrackersController(ITrackerService trackerService, IConnectionService connectionService, ILogger<TrackersController> logger)
        {
            _trackerService = trackerService;
            _connectionService = connectionService;
            _logger = logger;

        }

        [HttpGet("AccountId/{accountId}")]
        public async Task<IActionResult> GetAllAccountTrackers(Guid accountId)
        {
            try 
            { 
                var trackerIds = _connectionService.GetAllConnections().Where(x => x.AccountId == accountId).Select(x => x.TrackerId);
                var result = _trackerService.GetAllTrackers().Where(x => trackerIds.Contains(x.Id));

                return Ok(result);
            }
            catch (ConnectionServiceException ex)
            {
                _logger.LogError(ex, "Exception in GetAllAccountTrackers method");
                return BadRequest(ex.Message);
            }
            catch (TrackerServiceException ex)
            {
                _logger.LogError(ex, "Exception in GetAllAccountTrackers method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in GetAllAccountTrackers method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("FamilyId/{familyId}")]
        public async Task<IActionResult> GetAllFamilyTrackers(Guid familyId)
        {
            try 
            { 
                var trackerIds = _connectionService.GetAllConnections().Where(x => x.FamilyId == familyId).Select(x => x.TrackerId);
                var result = _trackerService.GetAllTrackers().Where(x => trackerIds.Contains(x.Id));

                return Ok(result);
            }
            catch (ConnectionServiceException ex)
            {
                _logger.LogError(ex, "Exception in GetAllFamilyTrackers method");
                return BadRequest(ex.Message);
            }
            catch (TrackerServiceException ex)
            {
                _logger.LogError(ex, "Exception in GetAllFamilyTrackers method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in GetAllFamilyTrackers method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewTracker([FromBody] Tracker tracker)
        {
            try 
            { 
                var result = _trackerService.AddNewTracker(tracker);

                return Ok(result);
            }
            catch (TrackerServiceException ex)
            {
                _logger.LogError(ex, "Exception in AddNewTracker method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in AddNewTracker method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTracker([FromBody] Tracker tracker)
        {
            try 
            { 
                var result = _trackerService.UpdateTracker(tracker);

                return Ok(result);
            }
            catch (TrackerServiceException ex)
            {
                _logger.LogError(ex, "Exception in UpdateTracker method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in UpdateTracker method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTracker(Guid id)
        {
            try 
            { 
                _trackerService.DeleteTracker(id);

                return Ok("Tracker was deleted");
            }

            catch (TrackerServiceException ex)
            {
                _logger.LogError(ex, "Exception in DeleteTracker method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in DeleteTracker method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllTrackers()
        {
            try
            {
                var result = _trackerService.GetAllTrackers();

                return Ok(result);
            }
            catch (TrackerServiceException ex)
            {
                _logger.LogError(ex, "Exception in GetAllTrackers method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in GetAllTrackers method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrackerById(Guid id)
        {
            try 
            { 
                var result = _trackerService.GetTrackerById(id);

                return Ok(result);
            }
            catch (TrackerServiceException ex)
            {
                _logger.LogError(ex, "Exception in GetTrackerById method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in GetTrackerById method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
