using Microsoft.AspNetCore.Mvc;
using SixDegrees.Business;
using SixDegrees.Dto;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SixDegrees.Controllers
{
    [ApiController]
    [Route("api")]
    public class SisDregreesController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;
        public SisDregreesController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> GetAllUsersAsync()
        {

            List<UserDto> users = new List<UserDto>();
            try
            {
                users = await _userBusiness.GetUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, por ejemplo, devolver un error 500
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

       
    }
}
