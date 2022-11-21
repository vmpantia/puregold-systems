using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Puregold.API.Contractors;
using Puregold.API.Exceptions;
using Puregold.API.Models.Request;

namespace Puregold.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _account;
        private readonly IUtilityService _utility;
        public AccountController(IAccountService account, IUtilityService utility)
        {
            _account = account;
            _utility = utility;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginRequest request)
        {
            try
            {
                var response = await _account.LoginAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("SaveAccount")]
        public async Task<IActionResult> SaveAccountAsync(AccountRequest request)
        {
            try
            {
                //Not valid AccessKey
                if (!await _utility.IsAccessKeyValid(request.clientInfo.AccessKey))
                {
                    return Unauthorized();
                }

                await _account.SaveAccount(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
