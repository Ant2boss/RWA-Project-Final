using RWA_DataLayer.DataRepository;
using RWA_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA_Project.Controllers.WebAPI.DataTransferObjects
{
	public class StavkaDTO
	{
		readonly string CS = System.Configuration.ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

		public void SetFrom(Stavka stavka)
		{
			this.IDStavka = stavka.IDStavka;
			this.RacunID = stavka.RacunID;
			this.Kolicina = stavka.Kolicina;
			this.ProizvodID = stavka.ProizvodID;
			this.CijenaPoKomadu = stavka.CijenaPoKomadu;
			this.PopustUPostotcima = stavka.PopustUPostotcima;
			this.UkupnaCijena = stavka.UkupnaCijena;

			ISimpleRepo<Proizvod> ProizvodRepo = SqlRepoFactory.GetProizvodRepo(this.CS);
			this.NazivProizvoda = ProizvodRepo.Get(this.ProizvodID).Naziv;

			ISimpleRepo<Potkategorija> PotkategorijaRepo = SqlRepoFactory.GetPotkategorijaRepo(this.CS);
			this.PotkategorijaID = ProizvodRepo.Get(this.ProizvodID).PotkategorijaID;
			if (this.PotkategorijaID != 0)
			{ 
				this.NazivPotkategorije = PotkategorijaRepo.Get(this.PotkategorijaID).Naziv;
			}

			ISimpleRepo<Kategorija> KategorijaRepo = SqlRepoFactory.GetKategorijaRepo(this.CS);
			if (this.PotkategorijaID != 0)
			{ 
				this.KategorijaID = PotkategorijaRepo.Get(this.PotkategorijaID).KategorijaID;
				if (this.KategorijaID != 0)
				{ 
					this.NazivKategorije = KategorijaRepo.Get(this.KategorijaID).Naziv;
				}
			}

			ISimpleRepo<Racun> RacunRepo = SqlRepoFactory.GetRacunRepo(this.CS);
			ISimpleRepo<KreditnaKartica> KarticaRepo = SqlRepoFactory.GetKreditnaKarticaRepo(this.CS);
			this.KreditnaKarticaID = RacunRepo.Get(this.RacunID).KreditnaKarticaID;
			if (this.KreditnaKarticaID != 0)
			{ 
				this.TipKreditneKartice = KarticaRepo.Get(this.KreditnaKarticaID).Tip;
			}

			ISimpleRepo<Komercijalist> KomercijalistRepo = SqlRepoFactory.GetKomercijalistRepo(this.CS);
			this.KomercijalistID = RacunRepo.Get(this.RacunID).KomercijalistID;
			if (this.KomercijalistID != 0)
			{ 
				Komercijalist temp = KomercijalistRepo.Get(this.KomercijalistID);
				this.NazivKomercijalista = temp.Ime + " " + temp.Prezime;
			}
		}

		public int IDStavka { get; set; }
		public int ProizvodID { get; set; }
		public string NazivProizvoda { get; set; }
		public int PotkategorijaID { get; set; }
		public string NazivPotkategorije { get; set; }
		public int KategorijaID { get; set; }
		public string NazivKategorije { get; set; }
		public int RacunID { get; set; }
		public int KreditnaKarticaID { get; set; }
		public string TipKreditneKartice { get; set; }
		public int KomercijalistID { get; set; }
		public string NazivKomercijalista { get; set; }

		public int Kolicina { get; set; }
		public decimal CijenaPoKomadu { get; set; }
		public decimal PopustUPostotcima { get; set; }
		public decimal UkupnaCijena { get; set; }
	}
}