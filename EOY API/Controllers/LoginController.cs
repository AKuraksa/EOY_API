using EOY_API.Classes;
using EOY_API.db;
using EOY_API.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Windows.UI.Notifications;

namespace EOY_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private const string GET_ROUTE = ApiParameters.GetRoute;
        private const string PUT_ROUTE = ApiParameters.PutRoute;
        private const string PATCH_ROUTE = ApiParameters.PatchRoute;
        private const string POST_ROUTE = ApiParameters.PostRoute;
        private const string DELETE_ROUTE = ApiParameters.DeleteRoute;
        private readonly EoyDbContext _context;

        public LoginController(EoyDbContext context)
        {
            _context = context;

        }

        [HttpGet("/FindUser")]
        public IActionResult Get(string username, string password)
        {
            var listUsers = _context.Logins.Where(x=> x.Username == username 
            && x.Password == password ).ToList();


            return Ok(listUsers);
        }

        [HttpGet(ApiParameters.GetRoute)]
        public IActionResult Get()
        {
            var listUsers = _context.Logins.ToList();


            return Ok(listUsers);
        }

        [HttpGet("/GetDataByLastName")]
        public IActionResult GetDataByLastName(string Lastname)
        {
            var User = _context.Logins
                .Where(x => x.LastName == Lastname)
                .ToList();


            return Ok("Deleted");
        }

       

        [HttpPost(ApiParameters.PostRoute)]
        public IActionResult CreateLogin(
            string username,
            string password,
            string email,
            string firstName,
            string lastName,
            bool admin)
        {
            var NewLogin = new Login
            {
                Username=username,
                Password=password,
                Email=email,
                FirstName=firstName,
                LastName= lastName,
                Permission = admin
            };
            if (!string.IsNullOrEmpty(username)
                || !string.IsNullOrEmpty(password)
                || !string.IsNullOrEmpty(email)
                || !string.IsNullOrEmpty(firstName)
                || !string.IsNullOrEmpty(lastName))
            {
                _context.Logins.Add(NewLogin);
                return Ok(_context.SaveChanges());
            }                 
            else
            {
                return BadRequest("data missing");
            }
        }

        [HttpPatch("/DataChangeOfUser")]
        public IActionResult PutData(
    Guid idSet,
    string username = null,
    string password = null,
    string email = null,
    string firstName = null,
    string lastName = null,
    bool? permission = null)
        {
            var user = _context.Logins.FirstOrDefault(u => u.id == idSet);

            if (user == null)
            {
                return NotFound();
            }

            // Aktualizace pouze neprázdných hodnot
            if (!string.IsNullOrEmpty(username))
            {
                user.Username = username;
            }
            if (!string.IsNullOrEmpty(password))
            {
                user.Password = password;
            }
            if (!string.IsNullOrEmpty(email))
            {
                user.Email = email;
            }
            if (!string.IsNullOrEmpty(firstName))
            {
                user.FirstName = firstName;
            }
            if (!string.IsNullOrEmpty(lastName))
            {
                user.LastName = lastName;
            }
            if (permission.HasValue)
            {
                user.Permission = permission.Value;
            }

            _context.SaveChanges();

            return Ok("User data updated successfully");
        }



        [HttpDelete(ApiParameters.DeleteRoute)]
        public IActionResult DeleteById(Guid id)
        {
            var user = _context.Logins
                .FirstOrDefault(x => x.id == id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Logins.Remove(user);
            _context.SaveChanges();

            return Ok();
        }
    }

}