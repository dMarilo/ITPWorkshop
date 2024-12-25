using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITPWorkshop.DTO;
using ITPWorkshop.Interfaces;
using ITPWorkshop.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITPWorkshop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        /*private static List<User> korisnici = new List<User>
        {
            new User(),
            new User{ Id = 1, Username = "Goran"}
        };

        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return Ok(korisnici);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            foreach(User u in korisnici)
            {
                if(u.Id == id)
                {
                    return Ok(u);
                }
            }
            return NotFound();
        }*/

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }
        
        [HttpPost("RegisterUser")]

        public async Task<IActionResult> RegisterUser(UserRegisterDTO registerDTO)
        {
            await _userService.Register(registerDTO);
            return Ok();
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<ActionResult<UserRegisterDTO>> GetUserById(int id)
        {
            var user =await _userService.GetUserById(id);
            return Ok(user);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserRegisterDTO>> Login(UserLoginDTO loginDTO)
        {
            await _userService.Login(loginDTO);
            return Ok();
        }

    }
}