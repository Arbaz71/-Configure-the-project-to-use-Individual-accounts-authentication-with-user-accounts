using CodingExercise.Data;
using CodingExercise.Dto;
using CodingExercise.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodingExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDto loginRequest)
        {
            var user = await _context.UserManager.FirstOrDefaultAsync(u => u.EmailAddress == loginRequest.EmailAddress);

            if (user == null)
            {
                return BadRequest("Invalid email");
            }

           if(user.Password.Equals(loginRequest.Password))
            {
                return Ok("Login Successfully");
            }
            else
            {
                return BadRequest("Invalid email");
            }

        }

        [HttpPost("AddUser")]
        public async Task<ActionResult<UserManagers>> AddUser(UserDto userManager)
        {
            UserManagers userManagersObj = new UserManagers
            {
                FirstName = userManager.FirstName,
                LastName = userManager.LastName,
                EmailAddress = userManager.EmailAddress,
                Password = userManager.Password
            };
            _context.UserManager.Add(userManagersObj);
            await _context.SaveChangesAsync();
            return Ok(userManager);
        }
    }
}
