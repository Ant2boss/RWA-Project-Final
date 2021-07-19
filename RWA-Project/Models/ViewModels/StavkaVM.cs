using RWA_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA_Project.Models.ViewModels
{
	public class StavkaVM : IViewModelConverter<Stavka>
	{
		public int IDStavka { get; set; }
		public int RacunID { get; set; }
		public int Kolicina { get; set; }
		public int ProizvodID { get; set; }
		public decimal CijenaPoKomadu { get; set; }
		public decimal PopustUPostotcima { get; set; }
		public decimal UkupnaCijena { get; set; }

		public void SetFrom(Stavka val)
		{
			this.IDStavka = val.IDStavka;
			this.RacunID = val.RacunID;
			this.Kolicina = val.Kolicina;
			this.ProizvodID = val.ProizvodID;
			this.CijenaPoKomadu = val.CijenaPoKomadu;
			this.PopustUPostotcima = val.PopustUPostotcima;
			this.UkupnaCijena = val.UkupnaCijena;
		}

		public Stavka ConvertBack() => new Stavka
		{
			IDStavka = this.IDStavka,
			RacunID = this.RacunID,
			Kolicina = this.Kolicina,
			ProizvodID = this.ProizvodID,
			CijenaPoKomadu = this.CijenaPoKomadu,
			PopustUPostotcima = this.PopustUPostotcima,
			UkupnaCijena = this.UkupnaCijena
		};
	}
}