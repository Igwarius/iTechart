using System.Threading.Tasks;
using ItechartProj.DAL.Models;
using ItechartProj.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ItechartProj.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly IUserService _userService;

        public UserController(IUserService userService, IRefreshTokenService refreshTokenService)
        {
            _userService = userService;
            _refreshTokenService = refreshTokenService;
        }

        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }

        [HttpPost]
        [Route("user")]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            await _userService.AddUser(user);
            return Ok();
        }

        [HttpPost]
        [Route("sign-in")]
        public async Task<IActionResult> CheckUser([FromBody] User user)
        {
            var response = await _userService.CheckUser(user);
            if (response != null) return Ok(response);
            return NotFound();
        }

        [HttpPost]
        [Route("ban-user")]
        public async Task<IActionResult> BanUser([FromBody] BannedUser user)
        {
            await _userService.BanUser(user);
            return Ok();
        }
    }
}