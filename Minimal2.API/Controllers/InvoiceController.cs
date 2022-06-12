using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Minimal2.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetInvoice()
        {
            var username = HttpContext.User.Identity.Name.ToString();

            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).ToString();
            var result = username + " / " + userId;
            return Ok("Invoice : "+result);
        }
    }
}
