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
    public class UsersController : Controller
    {
        private IUserService _userService;
        private readonly ILogger<UsersController> _logger;
        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddNewUser([FromBody] User user)
        {
            try 
            { 
                var result = _userService.AddNewUser(user);

                return Ok(result);
            }
            catch (UserServiceException ex)
            {
                _logger.LogError(ex, "Exception in AddNewUser method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in AddNewUser method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            try 
            { 
                var result = _userService.UpdateUser(user);

                return Ok(result);
            }
            catch (UserServiceException ex)
            {
                _logger.LogError(ex, "Exception in UpdateUser method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in UpdateUser method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try 
            { 
                _userService.DeleteUser(id);

                return Ok("User was deleted");
            }
            catch (UserServiceException ex)
            {
                _logger.LogError(ex, "Exception in DeleteUser method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in DeleteUser method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try 
            { 
                var result = _userService.GetAllUsers();

                return Ok(result);
            }
            catch (UserServiceException ex)
            {
                _logger.LogError(ex, "Exception in GetAllUsers method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in GetAllUsers method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            try 
            { 
                var result = _userService.GetUserById(id);

                return Ok(result);
            }
            catch (UserServiceException ex)
            {
                _logger.LogError(ex, "Exception in GetUserById method");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception in GetUserById method");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
