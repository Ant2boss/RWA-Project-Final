using RWA_DataLayer.DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWA_DataLayer.Models
{
	public class Komercijalist : ISqlParameterable
	{
		public int IDKomercijalist { get; set; }
		public string Ime { get; set; }
		public string Prezime { get; set; }
		public bool StalniZaposlenik { get; set; }

		public object[] GetSqlParamsList() => new object[] { this.Ime, this.Prezime, this.StalniZaposlenik };
	}
}
