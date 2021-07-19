using RWA_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA_Project.Models.ViewModels
{
	public class RacunVM : IViewModelConverter<Racun>
	{
		public int IDRacun { get; set; }
		public DateTime DatumIzdavanja { get; set; }
		public string BrojRacuna { get; set; }
		public int KupacID { get; set; }
		public int KomercijalistID { get; set; }
		public int KreditnaKarticaID { get; set; }
		public string Komentar { get; set; }

		public void SetFrom(Racun val)
		{
			this.IDRacun = val.IDRacun;
			this.DatumIzdavanja = val.DatumIzdavanja;
			this.BrojRacuna = val.BrojRacuna;
			this.KupacID = val.KupacID;
			this.KomercijalistID = val.KomercijalistID;
			this.KreditnaKarticaID = val.KreditnaKarticaID;
			this.Komentar = val.Komentar;
		}

		public Racun ConvertBack() => new Racun
		{
			IDRacun = this.IDRacun,
			DatumIzdavanja = this.DatumIzdavanja,
			BrojRacuna = this.BrojRacuna,
			KupacID = this.KupacID,
			KomercijalistID = this.KomercijalistID,
			KreditnaKarticaID = this.KreditnaKarticaID,
			Komentar = this.Komentar
		};
	}
}