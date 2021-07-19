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
    public class PotkategorijaController : CustomControllerBase
    {
        public ISimpleRepo<Potkategorija> PotkategorijaRepo
        {
            get
            {
                if (this._PotkategorijaRepo == null)
                {
                    this._PotkategorijaRepo = SqlRepoFactory.GetPotkategorijaRepo(this.CS);
                }

                return this._PotkategorijaRepo;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(this.PotkategorijaRepo.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
		{
			this._GetKategorijaSelectList();
			return this.View();
		}
		[HttpPost]
        public ActionResult Create(PotkategorijaVM data)
        {
            if (this.ModelState.IsValid)
            {
                this.PotkategorijaRepo.Create(data.ConvertBack());
                return this.RedirectToAction(actionName: "Index");
            }

            this._GetKategorijaSelectList();
            return this.View(data);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
			try
			{
				this._GetKategorijaSelectList();

				PotkategorijaVM model = new PotkategorijaVM();

				model.SetFrom(this.PotkategorijaRepo.Get(id));

				return this.View(model);
			}
			catch
			{
                return this.CustomRedirectToError($"Nije pronađena potkaegorija sa id: {id}");
			}
        }
        [HttpPost]
        public ActionResult Edit(PotkategorijaVM data)
        {
            if (this.ModelState.IsValid)
            {
                this.PotkategorijaRepo.Update(data.IDPotkategorija, data.ConvertBack());
                return this.RedirectToAction(actionName: "Index");
            }

            this._GetKategorijaSelectList();
            return this.View(data);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
			try
			{
				this.PotkategorijaRepo.Delete(id);
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
            if (id == 0)
            {
                return this.Content("-/-");
            }

            return this.Content(this.PotkategorijaRepo.Get(id).Naziv);
        }

        private void _GetKategorijaSelectList()
        {
            SelectList ddlList = new SelectList(
                items: SqlRepoFactory.GetKategorijaRepo(this.CS).GetAll(),
                dataValueField: "IDKategorija",
                dataTextField: "Naziv");

            this.ViewBag.ddlList = ddlList;
        }

        private ISimpleRepo<Potkategorija> _PotkategorijaRepo;
    }
}