using EOY_API.db;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EOY_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly EoyDbContext _context;

        public LoginController(EoyDbContext context)
        {
            _context = context;

        }

        [HttpGet("/All_Data_FROM_Logins")]
        public IActionResult Get()
        {
            var LIST_of_USERS = _context.Logins.ToList();


            return Ok(LIST_of_USERS);
        }

        [HttpGet("/GetDataByLastName")]
        public IActionResult Get(string Lastname)
        {
            var User = _context.Logins
                .Where(x => x.Last_name == Lastname)
                .ToList();


            return Ok(User);
        }


    }
}