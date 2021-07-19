using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RWA_Project.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index(string msg)
        {
            this.ViewData["error-msg"] = msg;
            return View();
        }
    }
}