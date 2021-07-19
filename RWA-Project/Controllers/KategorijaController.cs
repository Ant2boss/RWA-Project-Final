using RWA_DataLayer.DataRepository;
using RWA_DataLayer.Models;
using RWA_Project.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RWA_Project.Controllers
{
    [Authorize]
    public class KategorijaController : CustomControllerBase
    {
        public ISimpleRepo<Kategorija> KategorijaRepo
        {
            get
            {
                if (this._KategorijaRepo == null)
                {
                    this._KategorijaRepo = SqlRepoFactory.GetKategorijaRepo(this.CS);
                }

                return this._KategorijaRepo;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(this.KategorijaRepo.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }
        [HttpPost]
        public ActionResult Create(KategorijaVM data)
        {
            if (this.ModelState.IsValid)
            {
                this.KategorijaRepo.Create(data.ConvertBack());
                return this.RedirectToAction(actionName: "Index");
            }

            return this.View(data);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
			try
			{
				KategorijaVM model = new KategorijaVM();

				model.SetFrom(this.KategorijaRepo.Get(id));

				return this.View(model);
			}
			catch
			{
                return this.RedirectToAction(actionName: "Index", controllerName: "Error", routeValues: new { msg = $"Ne postoji kategoirja sa id: {id}"});
			}
        }
        [HttpPost]
        public ActionResult Edit(KategorijaVM data)
        {
            if (this.ModelState.IsValid)
            {
                this.KategorijaRepo.Update(data.IDKategorija, data.ConvertBack());
                return this.RedirectToAction(actionName: "Index");
            }

            return this.View(data);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
			try
			{
				this.KategorijaRepo.Delete(id);

				return this.RedirectToAction(actionName: "Index");
			}
			catch
			{
                this.CustomRaisePopup("Brisanje nije uspjelo!");
				return this.RedirectToAction("Index");
			}
        }

        [ChildActionOnly]
        [AllowAnonymous]
        public ActionResult GetNaziv(int id)
        {
            return this.Content(this.KategorijaRepo.Get(id).Naziv);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.Result = this.RedirectToAction(actionName: "Index", "Error", routeValues: new { msg = "Something went wrong" });
            filterContext.ExceptionHandled = true;
        }

        private ISimpleRepo<Kategorija> _KategorijaRepo;
    }
}