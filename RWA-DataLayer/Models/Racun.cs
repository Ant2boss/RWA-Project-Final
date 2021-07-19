using RWA_DataLayer.DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWA_DataLayer.Models
{
	public class Racun : ISqlParameterable
	{
		public int IDRacun { get; set; }
		public DateTime DatumIzdavanja { get; set; }
		public string BrojRacuna { get; set; }
		public int KupacID { get; set; }
		public int KomercijalistID { get; set; }
		public int KreditnaKarticaID { get; set; }
		public string Komentar { get; set; }

		public object[] GetSqlParamsList() => new object[] { this.DatumIzdavanja, this.BrojRacuna, this.KupacID, this.KomercijalistID, this.KreditnaKarticaID, this.Komentar };
	}
}
