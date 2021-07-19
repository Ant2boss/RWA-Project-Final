using RWA_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA_Project.Models.ViewModels
{
	public class KreditnaKarticaVM : IViewModelConverter<KreditnaKartica>
	{
		public int IDKreditnaKartica { get; set; }
		public string Tip { get; set; }
		public string Broj { get; set; }
		public int IstekMjesec { get; set; }
		public int IstekGodina { get; set; }

		public void SetFrom(KreditnaKartica val)
		{
			this.IDKreditnaKartica = val.IDKreditnaKartica;
			this.Tip = val.Tip;
			this.Broj = val.Broj;
			this.IstekMjesec = val.IstekMjesec;
			this.IstekGodina = val.IstekGodina;
		}

		public KreditnaKartica ConvertBack() => new KreditnaKartica
		{ 
			IDKreditnaKartica = this.IDKreditnaKartica,
			Tip = this.Tip,
			Broj = this.Broj,
			IstekMjesec = this.IstekMjesec,
			IstekGodina = this.IstekGodina
		};
	}
}