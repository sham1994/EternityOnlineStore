using System;
using System.Threading.Tasks;
using EternityStore.API.Dtos;
using EternityStore.API.Models;

namespace EternityStore.API.BusinessLayer
{
    public interface IAuthBusinessLayer
    {
        Task<UserForLoginDto>  Login(string username, string password);
        Task<UserForRegisterDto> Register(string username,string password,string address1, string address2, string city, string country, string gender, DateTime dateofbirth);

    }
}