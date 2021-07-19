using RWA_DataLayer.DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWA_DataLayer.Models
{
	public class Stavka : ISqlParameterable
	{
		public int IDStavka { get; set; }
		public int RacunID { get; set; }
		public int Kolicina { get; set; }
		public int ProizvodID { get; set; }
		public decimal CijenaPoKomadu { get; set; }
		public decimal PopustUPostotcima { get; set; }
		public decimal UkupnaCijena { get; set; }

		public object[] GetSqlParamsList() => new object[] { this.RacunID, this.Kolicina, this.ProizvodID, this.CijenaPoKomadu, this.PopustUPostotcima, this.UkupnaCijena };
	}
}
