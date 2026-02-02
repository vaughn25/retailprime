using Microsoft.AspNetCore.Mvc;
using Prime.Library.Repositories;
using Prime.Models;

namespace Prime.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase 
    {
        private readonly IUserRepository _userRepo;

        public UsersController(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers() 
        { 
            return Ok(await _userRepo.GetUsers());
        }

        [HttpGet]
        [Route("GetByUsernamePassword")]
        public async Task<IActionResult> GetByUsernamePassword([FromBody] UserDTO user) 
        { 
            return Ok(await _userRepo.GetByUsernamePassword(user.Username, user.Password));
        }
    }
}
