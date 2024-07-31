using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCrm.Application.Extensions;
using MyCrm.Application.Interfaces;

namespace MyCrm.Web.Controllers
{
    public class HomeController : BaseController
    {
        #region ctor
        private readonly IProgramSetting _programSetting;
        public HomeController(IProgramSetting programSetting)
        {
            _programSetting = programSetting;
        }
        #endregion
        public async Task<IActionResult>  Index()
        {
            var result = await _programSetting.FillDashboardViewModel(User.GetUserId());
            return View(result);
        }
    }
}
