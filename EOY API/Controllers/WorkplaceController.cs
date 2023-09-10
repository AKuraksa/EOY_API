using EOY_API.db;
using EOY_API.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Windows.Networking;
using EOY_API.Classes;
using System.Reflection.Metadata;

namespace EOY_API.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class WorkplaceController : ControllerBase
    {
        ApiParameters sa = new ApiParameters();
        private readonly EoyDbContext _context;
        private const string GET_ROUTE = ApiParameters.GetRoute;
        private const string PUT_ROUTE = ApiParameters.PutRoute;
        private const string PATCH_ROUTE = ApiParameters.PatchRoute;
        private const string POST_ROUTE = ApiParameters.PostRoute;
        private const string DELETE_ROUTE = ApiParameters.DeleteRoute;

        public WorkplaceController(EoyDbContext context) 
        {
            _context = context;
          
        }
        [HttpGet(GET_ROUTE)]
        public IActionResult GetAllWorkplaces()
        {
            var allWorkplaces = _context.Workplaces.ToList();
            return Ok(allWorkplaces);
        }
        [HttpPost(POST_ROUTE)]
        public IActionResult PostNewWorkplace(string workplaceName, string ipv4, string macAdress, string deviceName)
        {
                var NewWorkplace = new Workplace
                {
                    ID = new Guid(),
                    WorkplaceName = workplaceName,
                    Ip = ipv4,
                    Mac = macAdress,
                    State = false,
                    DeviceName = deviceName,
                    GetHELP = false,
                    GetINFO = false
                };

            if (!string.IsNullOrEmpty(workplaceName)
            || !string.IsNullOrEmpty(ipv4)
            || !string.IsNullOrEmpty(macAdress)
            || !string.IsNullOrEmpty(deviceName))
            {
                _context.Workplaces.Add(NewWorkplace);
                
                return Ok(_context.SaveChanges());
            }
            else
            {
                return BadRequest("data missing");
            }
        }
    }
}

