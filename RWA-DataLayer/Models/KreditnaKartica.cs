using RWA_DataLayer.DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWA_DataLayer.Models
{
	public class KreditnaKartica : ISqlParameterable
	{
		public int IDKreditnaKartica { get; set; }
		public string Tip { get; set; }
		public string Broj { get; set; }
		public int IstekMjesec { get; set; }
		public int IstekGodina { get; set; }

		public object[] GetSqlParamsList() => new object[] { this.Tip, this.Broj, this.IstekMjesec, this.IstekGodina };
	}
}
