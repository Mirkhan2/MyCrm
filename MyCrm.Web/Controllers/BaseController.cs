using Microsoft.AspNetCore.Mvc;

namespace MyCrm.Web.Controllers
{
	public class BaseController : Controller
	{
		protected string SuccessMessage = "SuccessMessage";
		protected string Errormessage = "Errormessage";
		protected string WarningMessage = "WarningMessage";
		protected string InfoMessage = "InfoMessage";
	}
}
