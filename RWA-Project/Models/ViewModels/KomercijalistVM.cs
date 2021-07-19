using RWA_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA_Project.Models.ViewModels
{
	public class KomercijalistVM : IViewModelConverter<Komercijalist>
	{
		public int IDKomercijalist { get; set; }
		public string Ime { get; set; }
		public string Prezime { get; set; }
		public bool StalniZaposlenik { get; set; }

		public void SetFrom(Komercijalist val)
		{
			this.IDKomercijalist = val.IDKomercijalist;
			this.Ime = val.Ime;
			this.Prezime = val.Prezime;
			this.StalniZaposlenik = val.StalniZaposlenik;
		}

		public Komercijalist ConvertBack() => new Komercijalist
		{ 
			IDKomercijalist = this.IDKomercijalist,
			Ime = this.Ime,
			Prezime = this.Prezime,
			StalniZaposlenik = this.StalniZaposlenik
		};
	}
}