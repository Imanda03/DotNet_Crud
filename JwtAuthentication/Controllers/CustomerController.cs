using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles ="Manager")]
        public IEnumerable<string> Get()
        {
            return new string[] { "Anish Sharma", "ANish Sharma" };
        }
    }
}
