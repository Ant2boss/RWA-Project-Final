using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RWA_Project.Controllers
{
    public class HomeController : CustomControllerBase
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}