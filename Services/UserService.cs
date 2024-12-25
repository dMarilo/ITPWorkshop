using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITPWorkshop.Data;
using ITPWorkshop.DTO;
using ITPWorkshop.Interfaces;
using ITPWorkshop.Models;
using Microsoft.EntityFrameworkCore;

namespace ITPWorkshop.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            this._context = context;
        }
        public async Task<UserRegisterDTO> GetUserById(int id)
        {
            UserRegisterDTO userDto = new UserRegisterDTO();
            try{
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

                if(userDto == null)
                {
                    throw new Exception("Korisnik sa ovim Id-em nije pronadjen!");
                }
                userDto.Username = user.Username;
                userDto.Ime = user.Ime;
                userDto.Prezime = user.Prezime;
                userDto.Adresa = user.Adresa;
                userDto.BrojTelefona = user.BrojTelefona;

                return userDto;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public async Task<UserRegisterDTO> Login(UserLoginDTO loginDto)
        {
            UserRegisterDTO userDto=null;
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == loginDto.Username);
            var password = Encoding.UTF8.GetBytes(loginDto.Password + user.PasswordSalt);

            if(user.PasswordHash.SequenceEqual(password))
            {
                userDto = new UserRegisterDTO();
                userDto.Username = user.Username;
                userDto.Ime = user.Ime;
                userDto.Prezime = user.Prezime;
                userDto.Adresa = user.Adresa;
                userDto.BrojTelefona = user.BrojTelefona;
            }
            if (userDto == null)
            {
                throw new Exception("Pogresna lozinka!!");
            }
            return userDto;
        }

        public async Task Register(UserRegisterDTO registerDto)
        {
            var user = new User();
            user.Username = registerDto.Username;
            user.Ime = registerDto.Ime;
            user.Prezime = registerDto.Prezime;
            user.Adresa = registerDto.Adresa;
            user.BrojTelefona = registerDto.BrojTelefona;
            user.PasswordSalt = Encoding.UTF8.GetBytes("YourSalt");
            user.PasswordHash = Encoding.UTF8.GetBytes(registerDto.Password + user.PasswordSalt);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

        }
    }
}