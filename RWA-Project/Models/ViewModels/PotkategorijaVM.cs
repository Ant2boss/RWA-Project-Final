using RWA_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RWA_Project.Models.ViewModels
{
	public class PotkategorijaVM : IViewModelConverter<Potkategorija>
	{
		public int IDPotkategorija { get; set; }

		[Required(ErrorMessage = "Naziv is a requiered field!")]
		public string Naziv { get; set; }
		public int KategorijaID { get; set; }

		public void SetFrom(Potkategorija val)
		{
			this.IDPotkategorija = val.IDPotkategorija;
			this.Naziv = val.Naziv;
			this.KategorijaID = val.KategorijaID;
		}

		public Potkategorija ConvertBack() => new Potkategorija
		{
			IDPotkategorija = this.IDPotkategorija,
			Naziv = this.Naziv,
			KategorijaID = this.KategorijaID
		};
	}
}