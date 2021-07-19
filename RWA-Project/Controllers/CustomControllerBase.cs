using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RWA_Project.Controllers
{
	public class CustomControllerBase : Controller
	{
		public string CS => System.Configuration.ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

		public ActionResult CustomRedirectToError(string msg) 
		{
			return this.RedirectToAction(actionName: "Index", controllerName: "Error", routeValues: new { msg });
		}

		public void CustomRaisePopup(string popupMessage)
		{
			this.TempData["data-popup"] = popupMessage;
		}

		protected override void OnException(ExceptionContext filterContext)
		{
			filterContext.Result = this.RedirectToAction(actionName: "Index", "Error", routeValues: new { msg = "Something went wrong" });
			filterContext.ExceptionHandled = true;
		}
	}
}