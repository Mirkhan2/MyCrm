using Microsoft.AspNetCore.Mvc;

namespace MyCrm.Web.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
