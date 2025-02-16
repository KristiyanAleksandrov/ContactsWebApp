using Microsoft.AspNetCore.Mvc;

namespace ContactsWebApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        [HttpGet("contacts")]
        public async Task<ActionResult<List<int>>> GetContacts()
        {
            return new List<int>() { 1, 2, 3 };
        }

    }
}
