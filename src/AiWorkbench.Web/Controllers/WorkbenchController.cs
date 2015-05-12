using AiWorkbench.Web.Services;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;

namespace AiWorkbench.Web.Controllers
{
    public class WorkbenchController : Controller
    {
        private IHubContext _hubContext;

        public WorkbenchController(IConnectionManager connectionManager)
        {
            _hubContext = connectionManager.GetHubContext<SimulationHub>();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
