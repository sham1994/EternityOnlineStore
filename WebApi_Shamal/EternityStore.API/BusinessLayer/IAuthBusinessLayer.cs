using System.Threading.Tasks;
using EternityStore.API.Dtos;
using EternityStore.API.Models;

namespace EternityStore.API.BusinessLayer
{
    public interface IAuthBusinessLayer
    {
        Task<UserForLoginDto>  Login(string username, string password);

    }
}