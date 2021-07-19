using RWA_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RWA_Project.Models.ViewModels
{
	public class DrzavaVM : IViewModelConverter<Drzava>
	{
		public int IDDrzava { get; set; }

		[Required(ErrorMessage = "Naziv is a requiered field!")]
		public string Naziv { get; set; }

		public void SetFrom(Drzava val)
		{
			this.IDDrzava = val.IDDrzava;
			this.Naziv = val.Naziv;
		}

		public Drzava ConvertBack() => new Drzava
		{ 
			IDDrzava = this.IDDrzava,
			Naziv = this.Naziv
		};
	}
}