using Microsoft.AspNetCore.Mvc;

namespace MyCrm.Web.Controllers
{

	public class BaseController : Controller
	{
		protected string SuccessMessage = "SuccessMessage";
		protected string ErrorMessage = "ErrorMessage";
		protected string WarningMessage = "WarningMessage";
		protected string InfoMessage = "InfoMessage";
	}
}
