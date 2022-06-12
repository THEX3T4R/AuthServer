using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Excepitons;
using UdemyAuthServer.Core.DTOs;
using UdemyAuthServer.Core.Services;

namespace UdemyAuthServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CustomBaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            throw new CustomeException("db ile ilgili bir hata oldu");
            var result = await _userService.CreateUserAsync(createUserDto);
            return ActionResultInstance(result);
        }

        [Authorize]
        [HttpGet]
        public  async Task<IActionResult> GetUserByNameAsync()
        {
            return ActionResultInstance(await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name));
        }

    }
}
