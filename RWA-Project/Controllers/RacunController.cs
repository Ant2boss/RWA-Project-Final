using RWA_DataLayer.DataRepository;
using RWA_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RWA_Project.Controllers
{
    [Authorize]
    public class RacunController : CustomControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
    }
}