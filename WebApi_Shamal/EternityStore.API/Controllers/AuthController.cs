using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EternityStore.API.BusinessLayer;
using EternityStore.API.Data;
using EternityStore.API.Dtos;
using EternityStore.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EternityStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IAuthBusinessLayer _authBusinessLayer;
        public AuthController(IAuthBusinessLayer D, IConfiguration config)
        {
            _authBusinessLayer = authBusinessLayer;
            _config = config;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
         {
             //userForRegisterDto.Username = userForRegisterDto.Username.ToLower();
        //     if (await _repo.UserExists(userForRegisterDto.Username))
        //         return BadRequest("Username already exists");

        //     var userToCreate = new User
        //     {
        //         Username = userForRegisterDto.Username
        //     };

        //     var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);
           // return StatusCode(201);
        var userForRegister = await _authBusinessLayer.Register(userForRegisterDto.Username.ToLower(), userForRegisterDto.Password);
                if(userForRegister == null)
                
                    return BadRequest("Username already exists");
                
                
                return StatusCode(201);
        }
        

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            //throw new Exception("Computer Say no");
            var userForLogin = await _authBusinessLayer.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password);
            if(userForLogin == null)
            return Unauthorized();

            return Ok(new
            {
               token = userForLogin
            });

        }
    }
}