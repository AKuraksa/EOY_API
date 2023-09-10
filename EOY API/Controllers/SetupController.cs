using EOY_API.Classes;
using EOY_API.db;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EOY_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetupController : ControllerBase
    {
        private const string GET_ROUTE = ApiParameters.GetRoute;
        private const string PUT_ROUTE = ApiParameters.PutRoute;
        private const string PATCH_ROUTE = ApiParameters.PatchRoute;
        private const string POST_ROUTE = ApiParameters.PostRoute;
        private const string DELETE_ROUTE = ApiParameters.DeleteRoute;
        private readonly EoyDbContext _context;

        public SetupController(EoyDbContext context)
        {
            _context = context;
        }


        [HttpPost("CREATE DATABASE")]
        public ActionResult<string> CreateDatabaseAndTables()
        {
            try
            {   
                _context.Database.ExecuteSqlRaw($"ALTER LOGIN [eoyer] WITH PASSWORD = {"eoyer123"}, CHECK_POLICY = OFF, CHECK_EXPIRATION = OFF;");

                if(_context.Database != null)
                {
                    _context.Database.EnsureDeleted();
                    
                }

                else if (_context.Database == null)
                {
                    _context.Database.EnsureCreated();
                }
                   
                
                
                
                _context.SaveChanges();

                return Ok("Database was created");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Chyba při vytváření databáze a tabulek: {ex.Message}");
            }




        }
    }
}
