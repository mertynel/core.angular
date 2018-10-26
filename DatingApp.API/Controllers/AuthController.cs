using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository authRepository)
        {
            this._repo = authRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegister)
        {
            //validate
        
            userForRegister.Username = userForRegister.Username.ToLower();

            if(await _repo.userExist(userForRegister.Username))
                return BadRequest("User already exists");
            
            var userToCreate = new User 
            {
                Username = userForRegister.Username
            };

            var createdUser = await _repo.Register(userToCreate, userForRegister.Password);

            return Ok();
        }
    }
}