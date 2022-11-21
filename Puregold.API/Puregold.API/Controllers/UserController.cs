using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Puregold.API.Contractors;
using Puregold.API.Exceptions;
using Puregold.API.Models.Request;

namespace Puregold.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _user;
        public UserController(IUserService user)
        {
            _user = user;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginRequest request)
        {
            try
            {
                var response = await _user.LoginAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
