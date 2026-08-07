using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basic_Crud
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        public readonly IUserService _dbContext;
        public UserAuthController(IUserService dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("login")]
        public async Task<IActionResult> login(LoginModel obj)
        {
            try
            {
                var isExist = await _dbContext.login(obj);
                if (isExist != null)
                {
                    return Ok(isExist);
                }
                else
                {
                    return NotFound(new { message = "Invalid email or password" });
                }
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, new { error = ex.Message });
            }

        }

        [HttpPut("updatePassword")]
        public async Task<IActionResult> updatePassword(UpdatePasswordModel obj)
        {
            try
            {
                var isExist = await _dbContext.updatePassword(obj);
                if (isExist != null)
                {
                    return Ok(isExist);
                }
                else
                {
                    return NotFound(new { message = "Invalid userId or password" });
                }
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, new { error = ex.Message });
            }

        }
    }
}
