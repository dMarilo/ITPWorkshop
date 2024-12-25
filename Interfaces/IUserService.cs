using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITPWorkshop.DTO;
using ITPWorkshop.Models;

namespace ITPWorkshop.Interfaces
{
    public interface IUserService
    {
        public Task Register(UserRegisterDTO registerDto);
        public Task<UserRegisterDTO> Login(UserLoginDTO loginDto);

        public Task<UserRegisterDTO> GetUserById(int id);
    }
}