using EOY_API.Classes;
using EOY_API.db;
using EOY_API.Tables;
using Microsoft.AspNetCore.Mvc;
using Windows.Security.Credentials;
using Windows.Services.Maps;

namespace EOY_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        ApiParameters sa = new ApiParameters();
        private readonly EoyDbContext _context;
        private const string GET_ROUTE = ApiParameters.GetRoute;
        private const string PUT_ROUTE = ApiParameters.PutRoute;
        private const string PATCH_ROUTE = ApiParameters.PatchRoute;
        private const string POST_ROUTE = ApiParameters.PostRoute;
        private const string DELETE_ROUTE = ApiParameters.DeleteRoute;

        public WorkersController(EoyDbContext context)
        {
            _context = context;

        }
        [HttpPost(POST_ROUTE)]
        public IActionResult PostWorker(string workerFirstName, string workerLastName, string authentificatorId)
        {
            var NewWorker = new Worker
            {
                ID = new Guid(),
                Created = DateTime.Now,
                Updated = null,
                WorkerFirstName = workerFirstName.Trim(),
                WorkerLastName = workerLastName.Trim(),
                AuthentificatorID = authentificatorId.Trim(),
                LoggedWorkplace = null

            };

            if (!string.IsNullOrEmpty(workerFirstName)
            || !string.IsNullOrEmpty(workerLastName)
            || !string.IsNullOrEmpty(authentificatorId))
            {

                var workersList = _context.Workers.ToList();
                var passwordExist = workersList.Where(x => x.AuthentificatorID == authentificatorId).Any();
                if (!passwordExist)
                {
                    _context.Workers.Add(NewWorker);

                    return Ok(_context.SaveChanges());
                }
                else
                {
                    return BadRequest("AuthentificatorID already exist");
                }
            }
            else
            {
                return BadRequest("data missing");
            }

        }
        [HttpGet(GET_ROUTE)]
        public IActionResult GetWorkers()
        {
            return Ok(_context.Workers);
        }

        [HttpPatch(PATCH_ROUTE)]
        public IActionResult PatchData(Guid workerID, string mac)
        {
            var workplace = _context.Workplaces.FirstOrDefault(u => u.Mac == mac);

            if (workplace == null)
            {
                return NotFound();
            }

            // Aktualizace pouze neprázdných hodnot
            if (!string.IsNullOrEmpty(mac))
            {
                var worker = _context.Workers.Where(x => x.ID == workerID).FirstOrDefault();
                workplace.UserLogged = $"{worker.WorkerFirstName} {worker.WorkerLastName}";
                worker.Updated = DateTime.Now;
                workplace.State = true;
                worker.LoggedWorkplace = workplace.WorkplaceName;
            }

            _context.SaveChanges();

            return Ok("User data updated successfully");
        }

    }
}