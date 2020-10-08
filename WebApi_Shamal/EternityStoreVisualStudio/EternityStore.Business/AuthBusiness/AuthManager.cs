using EternityStore.Data.UnitOfWork;
using EternityStore.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EternityStore.API.BusinessLayer
{
    public class AuthBusinessLayer : IAuthManager
    {
        private readonly IConfiguration _config;
        private readonly IUnitOfWork _unitOfWork;

       

        public AuthBusinessLayer(IConfiguration config,IUnitOfWork unitOfWork)
        {
            _config = config;
            _unitOfWork = unitOfWork;
        }
        public async Task<UserForLoginDto> Login(UserForLoginDto userForLoginDto)
        {
            //Repository s
            var userFromRepo = await _unitOfWork.AuthRepository.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password);

            if (userFromRepo == null)
                return null;

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userForLoginDto.Id.ToString()),
                new Claim(ClaimTypes.Name , userForLoginDto.Username)
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

            string serializetoken = tokenHandler.WriteToken(token);

            return new UserForLoginDto
            {
                Token = serializetoken
            };

        }
        public async Task<UserForRegisterDto> Register(UserForRegisterDto userForRegisterDto)
        {
            try
            {
                userForRegisterDto.UserName = userForRegisterDto.UserName.ToLower();

                if (await _unitOfWork.AuthRepository.UserExists(userForRegisterDto.UserName))
                    return null;

                await _unitOfWork.AuthRepository.Register(userForRegisterDto, userForRegisterDto.Password);

                _unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return userForRegisterDto;





            





        }
    }
}