using EOY_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace EOY_API.Controllers
{
    [Route("api/EOYAPI")]
    [ApiController]
    public class EOYAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<EOY> GetEOYs()
        {
            return new List<EOY>
            {
                new EOY{Id=1}
            };
        }
        [HttpPost]
        public 
    }
}
