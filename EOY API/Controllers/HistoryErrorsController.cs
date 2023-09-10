using EOY_API.Classes;
using EOY_API.db;
using EOY_API.Tables;
using Microsoft.AspNetCore.Mvc;

namespace EOY_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryErrorsController : Controller
    {
        private readonly EoyDbContext _context;
      
        public HistoryErrorsController(EoyDbContext context)
        {
            _context = context;

        }

        [HttpGet(ApiParameters.GetRoute)]
        public IActionResult Get()
        {
            var listErrors = _context.HistoryErrors.ToList();


            return Ok(listErrors);
        }

        [HttpPost(ApiParameters.PostRoute)]
        public IActionResult CreateError(
            string typeError,
            string workplace
            )
        {
            var newError = new HistoryError
            {
               Date = DateTime.UtcNow,
               TypeError = typeError,
               WorkPlace = workplace



            };
            if (!string.IsNullOrEmpty(typeError)
                && !string.IsNullOrEmpty(workplace)) 
            {
                _context.HistoryErrors.Add(newError);
                return Ok(_context.SaveChanges());



            }
            else
            {
                return BadRequest("data missing");
            }
        }
    }
}
