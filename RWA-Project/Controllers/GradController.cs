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
    public class GradController : CustomControllerBase
    {
        public ISimpleRepo<Grad> GradRepo 
        {
            get
            {
                if (this._GradRepo == null)
                {
                    this._GradRepo = SqlRepoFactory.GetGradRepo(this.CS);
                }

                return this._GradRepo;
            }
        }

        [HttpGet]
        [AllowAnonymous]
		public ActionResult Index()
        {
            return View(this.GradRepo.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
		{
			this._GetDrzavaList();
			return this.View();
		}
		[HttpPost]
        public ActionResult Create(GradVM data)
        {
            if (this.ModelState.IsValid)
            {
                this.GradRepo.Create(data.ConvertBack());

                return this.RedirectToAction(actionName: "Index");
            }

            this._GetDrzavaList();
            return this.View(data);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
			try
			{
				GradVM model = new GradVM();

				model.SetFrom(this.GradRepo.Get(id));
				this._GetDrzavaList();

				return this.View(model);
			}
			catch
			{
                return this.RedirectToAction(actionName: "Index", controllerName: "Error", new { msg = $"Nije pronađen grad sa id: {id}" });
			}
        }
        [HttpPost]
        public ActionResult Edit(GradVM data)
        {
            if (this.ModelState.IsValid)
            {
                this.GradRepo.Update(data.IDGrad, data.ConvertBack());

                return this.RedirectToAction(actionName: "Index");
            }

            this._GetDrzavaList();
            return this.View(data);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
			try
			{
				this.GradRepo.Delete(id);

				return this.RedirectToAction(actionName: "Index");
			}
			catch
			{
                this.CustomRaisePopup("Brisanje nije uspjelo!");
                return this.RedirectToAction("Index");
			}
        }

        private void _GetDrzavaList()
        {
            IEnumerable<Drzava> drzavaList = SqlRepoFactory.GetDrzavaRepo(this.CS).GetAll();

            this.ViewBag.ddlList = new SelectList(items: drzavaList, dataValueField: "IDDrzava", dataTextField: "Naziv");
        }

        private ISimpleRepo<Grad> _GradRepo;
    }
}