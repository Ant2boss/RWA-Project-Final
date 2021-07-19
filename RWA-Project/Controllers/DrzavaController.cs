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
    public class DrzavaController : CustomControllerBase
    {
        public ISimpleRepo<Drzava> DrzavaRepo
        { 
            get 
            {
                if (this._DrzavaRepo == null)
                {
                    this._DrzavaRepo = SqlRepoFactory.GetDrzavaRepo(CS);
                }

                return this._DrzavaRepo;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return this.View(this.DrzavaRepo.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }
        [HttpPost]
        public ActionResult Create(DrzavaVM data)
        {
            if (this.ModelState.IsValid)
            {
                this.DrzavaRepo.Create(data.ConvertBack());
                return this.RedirectToAction(actionName: "Index");
            }

            return this.View(data);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
			try
			{
                DrzavaVM model = new DrzavaVM();

                model.SetFrom(this.DrzavaRepo.Get(id));

				return this.View(model);
			}
			catch
			{
                return this.RedirectToAction(actionName: "Index", controllerName: "Error", routeValues: new { msg = "Unable to find drzava!" });
			}
        }
        [HttpPost]
        public ActionResult Edit(DrzavaVM data)
        {
            if (this.ModelState.IsValid)
            {
                this.DrzavaRepo.Update(data.IDDrzava, data.ConvertBack());
                return this.RedirectToAction(actionName: "Index");
            }

            return this.View(data);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                this.DrzavaRepo.Delete(id);
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
            return this.Content(this.DrzavaRepo.Get(id).Naziv);
        }

		private ISimpleRepo<Drzava> _DrzavaRepo;
    }
}