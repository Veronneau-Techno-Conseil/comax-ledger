using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComaxLedgerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Accounts : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public IActionResult CreateAccount()
        {
            throw new NotImplementedException();
        }
    }
}
