using RWA_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA_Project.Models.ViewModels
{
	public class KupacVM : IViewModelConverter<Kupac>
	{
		public int IDKupac { get; set; }
		public string Ime { get; set; }
		public string Prezime { get; set; }
		public string Email { get; set; }
		public string Telefon { get; set; }
		public int GradID { get; set; }

		public void SetFrom(Kupac val)
		{
			this.IDKupac = val.IDKupac;
			this.Ime = val.Ime;
			this.Prezime = val.Prezime;
			this.Email = val.Email;
			this.Telefon = val.Telefon;
		}

		public Kupac ConvertBack() => new Kupac
		{ 
			IDKupac = this.IDKupac,
			Ime = this.Ime,
			Prezime = this.Prezime,
			Email = this.Email,
			Telefon = this.Telefon,
			GradID = this.GradID
		};
	}
}