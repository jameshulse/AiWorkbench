using Microsoft.AspNet.Mvc;

namespace AiWorkbench.Web.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
