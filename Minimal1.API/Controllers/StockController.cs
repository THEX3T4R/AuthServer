using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Minimal1.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStock()
        {
            var username = HttpContext.User.Identity.Name.ToString();

            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value.ToString();
            var result = username + " / " + userId;
            return Ok("Stock : " + result);
        }
    }
}
