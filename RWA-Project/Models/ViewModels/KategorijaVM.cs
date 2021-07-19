using RWA_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RWA_Project.Models.ViewModels
{
	public class KategorijaVM : IViewModelConverter<Kategorija>
	{
		public int IDKategorija { get; set; }
		[Required(ErrorMessage = "Naziv is a requiered field!")]
		public string Naziv { get; set; }

		public void SetFrom(Kategorija val)
		{
			this.IDKategorija = val.IDKategorija;
			this.Naziv = val.Naziv;
		}

		public Kategorija ConvertBack() => new Kategorija
		{
			IDKategorija = this.IDKategorija,
			Naziv = this.Naziv
		};
	}
}