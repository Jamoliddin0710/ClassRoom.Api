using ClassRoom.Entities;
using ClassRoom.Model;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClassRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class AccountController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(SignUpUser signUpUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (signUpUser.Password != signUpUser.ConfirmPassword)
            {
                return BadRequest();
            }

            if (_userManager.Users.Any(user=>user.UserName == signUpUser.UserName))
            {
                return NotFound();
            }

            var user = new User()
            {
                UserName = signUpUser.UserName,
                FirstName = signUpUser.FirstName,
                LastName = signUpUser.LastName,
            };
            await _userManager.CreateAsync(user, signUpUser.Password);
           
            await _signInManager.SignInAsync(user, isPersistent: true);


            return Ok();
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(SignInUser signInUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (!await _userManager.Users.AnyAsync(user => user.UserName == signInUser.UserName))
            {
                return NotFound();
            }

            var result = await _signInManager.PasswordSignInAsync(signInUser.UserName, signInUser.Password, isPersistent: true, false);
            if (!result.Succeeded)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> Profile(string username)
        {
            if(!await _userManager.Users.AnyAsync(user => user.UserName == username))
            {
                return NotFound();
            }
            var user = await _userManager.Users.FirstAsync(user => user.UserName == username);
            _logger.LogInformation("user login with id {0}",user.Id);
            //logger orqali consolega yozish
            var userdto = user.Adapt<UserDto>();
            //userdto ga userdagi userdto qabul qila oladigan qiymatlarni oladi 
            return Ok(userdto);
        }
        //logout
        
    }
}
