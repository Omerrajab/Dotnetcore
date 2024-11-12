using Findry.Data.Entities;
using Findry.Services;
using Microsoft.AspNetCore.Mvc;

namespace Findry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
        // GET: api/user/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetUserById(int id)
        {
            var category = await _userService.GetUserByIdAsync(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        // POST: api/user
        [HttpPost]
        public async Task<ActionResult<Category>> AddUser(User user)
        {
            await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }


    }
}
