using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        protected AuthController(IAuthRepository authRepository)
        {
            this._repo = authRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string password)
        {
            //validate

            username = username.ToLower();

            if(await _repo.userExist(username))
                return BadRequest("User already exists");
            
            var userToCreate = new User 
            {
                Username = username
            };

            var createdUser = await _repo.Register(userToCreate, password);

            return Ok();
        }
    }
}