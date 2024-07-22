using Microsoft.AspNetCore.Mvc;

namespace MyCrm.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
