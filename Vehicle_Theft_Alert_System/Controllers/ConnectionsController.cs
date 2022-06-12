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
    public class ConnectionsController : Controller
    {
        private IConnectionService _connectionService;
        private readonly ILogger<ConnectionsController> _logger;
        public ConnectionsController(IConnectionService connectionService, ILogger<ConnectionsController> logger)
        {
            _connectionService = connectionService;
            _logger = logger;

        }

        [HttpPost]
        public async Task<IActionResult> AddNewConnection([FromBody] Connection connection)
        {
            try 
            { 
            var result = _connectionService.AddNewConnection(connection);

            return Ok(result);
            }
            catch (ConnectionServiceException ex)
            {
                _logger.LogError(ex, "Exception in AddNewConnection method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in AddNewConnection method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateConnection([FromBody] Connection connection)
        {
            try 
            { 
            var result = _connectionService.UpdateConnection(connection);

            return Ok(result);
            }
            catch (ConnectionServiceException ex)
            {
                _logger.LogError(ex, "Exception in UpdateConnection method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in UpdateConnection method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConnection(Guid id)
        {
            try 
            { 
                _connectionService.DeleteConnection(id);

                return Ok("Country was deleted");
            }
            catch (ConnectionServiceException ex)
            {
                _logger.LogError(ex, "Exception in DeleteConnection method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in DeleteConnection method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllConnections()
        {
            try 
            { 
            var result = _connectionService.GetAllConnections();

            return Ok(result);
            }
            catch (ConnectionServiceException ex)
            {
                _logger.LogError(ex, "Exception in GetAllConnections method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in GetAllConnections method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetConnectionById(Guid id)
        {
            try 
            { 
            var result = _connectionService.GetConnectionById(id);

            return Ok(result);
            }
            catch (ConnectionServiceException ex)
            {
                _logger.LogError(ex, "Exception in GetConnectionById method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in GetConnectionById method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
