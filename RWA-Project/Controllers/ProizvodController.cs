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
    public class ProizvodController : CustomControllerBase
    {
        public ISimpleRepo<Proizvod> ProizvodRepo
        {
            get
            {
                if (this._ProizvodRepo == null)
                {
                    this._ProizvodRepo = SqlRepoFactory.GetProizvodRepo(this.CS);
                }

                return this._ProizvodRepo;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        { 
            return View(this.ProizvodRepo.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            this._GetPotkategorijaSelectList();
            return this.View();
        }
        [HttpPost]
        public ActionResult Create(ProizvodVM data)
        {
            if (this.ModelState.IsValid)
            {
                this.ProizvodRepo.Create(data.ConvertBack());
                return this.RedirectToAction(actionName: "Index");
            }

            this._GetPotkategorijaSelectList();
            return this.View(data);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
			try
			{
				ProizvodVM model = new ProizvodVM();

				model.SetFrom(this.ProizvodRepo.Get(id));

				this._GetPotkategorijaSelectList();
				return this.View(model);
			}
			catch
			{
                return this.CustomRedirectToError($"Nije pronađen proizvod sa id: {id}");
			}
        }
        [HttpPost]
        public ActionResult Edit(ProizvodVM data)
        {
            if (this.ModelState.IsValid)
            {
                this.ProizvodRepo.Update(data.IDProizvod, data.ConvertBack());
                return this.RedirectToAction(actionName: "Index");
            }

            this._GetPotkategorijaSelectList();
            return this.View(data);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
			try
			{
				this.ProizvodRepo.Delete(id);

				return this.RedirectToAction(actionName: "Index");
			}
			catch
			{
                this.CustomRaisePopup("Brisanje nije uspjelo");
                return this.RedirectToAction("Index");
			}
        }

        private void _GetPotkategorijaSelectList()
		{
            IList<Potkategorija> tempList = new List<Potkategorija>();

            tempList.Add(new Potkategorija { IDPotkategorija = 0, Naziv = "--No sub category--" });

            SelectList ddlList = new SelectList(
                items: tempList.Concat(SqlRepoFactory.GetPotkategorijaRepo(this.CS).GetAll()),
                dataValueField: "IDPotkategorija",
                dataTextField: "Naziv");

            this.ViewBag.ddlList = ddlList;
		}

		private ISimpleRepo<Proizvod> _ProizvodRepo;
    }
}