using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EternityStore.API.Data;
using EternityStore.API.Dtos;
using EternityStore.API.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EternityStore.API.BusinessLayer
{
    public class AuthBusinessLayer : IAuthBusinessLayer
    {
        private readonly IConfiguration _config;
        private readonly IAuthRepository _authrepo;
        public AuthBusinessLayer(IConfiguration config, IAuthRepository authrepo)
        {
            _authrepo = authrepo;
            _config = config;

        }
        public async Task<UserForLoginDto> Login(string username, string password)
        {

                var userFromRepo = await _authrepo.Login(username.ToLower(),password);
            if (userFromRepo == null)
                return null;
                
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var serializedToken = tokenHandler.WriteToken(token);

            return new UserForLoginDto{
                Token = serializedToken 
            };
            
        }
        public async Task<UserForRegisterDto> Register(string username, string password)
        {
            username = username.ToLower();
            //bool flag;
            
            if(await _authrepo.UserExists(username))
           return null;

           var userToCreate = new User
            {
                Username = username
              };
            var createdUser = await _authrepo.Register(userToCreate, password);
            return new UserForRegisterDto{
                Username = username,
                Password = password
            } ;
        }
    }
}