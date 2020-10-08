using System;
using System.Threading.Tasks;
using AutoMapper;
using EternityStore.Data.Model;
using EternityStore.Entity;
using Microsoft.EntityFrameworkCore;

namespace EternityStore.Data.Repository
{ 
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AuthRepository(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public  async Task<UserForLoginDto>  Login(string username, string password)
        {   //basically get customer => returning customer  ==>> these functionalitis should be in customer manager =CUSTOMER NMANAGER
            //TOKEN MANAGER TO GET TOKEN  through get customer ============> Reusability
            // llok into grouping functionalites
            var user = await _context.Users.FirstOrDefaultAsync(x=>x.Username == username.ToLower());
            
            if(user == null)
            {
                return null;
            }
            

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }
           


            return _mapper.Map<UserForLoginDto>(user);
            
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
           {
               
               //converts password to byte array
              var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
              for(int i = 0 ; i< computedHash.Length; i++)
              {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
           }
           return true;
        }

        public async Task<UserForRegisterDto> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            try
            {
                CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

                User user = _mapper.Map<UserForRegisterDto, User>(userForRegisterDto);

                //User user2 = _mapper.Map<UserForRegisterDto,User>(userForRegisterDto)

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                await _context.Users.AddAsync(user);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            return userForRegisterDto;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = hmac.Key;
            //converts password to byte array
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }


        public async Task<bool> UserExists(string username)
        {
            if(await _context.Users.AnyAsync(x => x.Username == username))
            {
                return true;
            }
            

            return false;

        }
    }
}