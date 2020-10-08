using EternityStore.Entity;
using System.Threading.Tasks;

namespace EternityStore.API.BusinessLayer
{
    public interface IAuthManager
    {
        Task<UserForLoginDto>  Login(UserForLoginDto userForLoginDto);
        Task<UserForRegisterDto> Register(UserForRegisterDto userForRegisterDto);

    }
}