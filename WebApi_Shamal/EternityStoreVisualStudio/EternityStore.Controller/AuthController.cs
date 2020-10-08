using EternityStore.API.BusinessLayer;
using EternityStore.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EternityStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthManager _authManagerLayer;
        

        public AuthController(IAuthManager authManagerLayer)

        {
            // layer remove
          _authManagerLayer = authManagerLayer;
         
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
         {
        // method should be save customer
        var userForRegister = await _authManagerLayer.Register(userForRegisterDto);
            if (userForRegister == null)
            {
                // Badrequest is not the proper code   
                return BadRequest("Username already exists");
            }
                
              
                return StatusCode(201);
        }
        

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            // token generation
            var userForLogin = await _authManagerLayer.Login(userForLoginDto);
            if (userForLogin == null)
                return Unauthorized();

           
            return Ok(new
            {
                token = userForLogin.Token

            });

        }
    }
}