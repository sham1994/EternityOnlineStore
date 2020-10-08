using EternityStore.Entity;
using System.Threading.Tasks;

namespace EternityStore.Data.Repository
{
    public interface IAuthRepository
    {
         Task<UserForRegisterDto> Register(UserForRegisterDto userForRegisterDto, string password);

         Task<UserForLoginDto> Login(string username,string password);

         Task<bool> UserExists(string username);
    }
} 