using EOY_API.db;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EOY_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkplaceController : ControllerBase
    {

        private readonly EoyDbContext _context;

        WorkplaceController(EoyDbContext context) 
        {
            _context = context;
        }
        [HttpGet("GetAllWorkplaces")]
        public IActionResult GetAllWorkplaces()
        {
            return Ok();
        }
    }
}
