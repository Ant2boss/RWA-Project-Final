using RWA_DataLayer.DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWA_DataLayer.Models
{
	public class Kupac : ISqlParameterable
	{
		public int IDKupac { get; set; }
		public string Ime { get; set; }
		public string Prezime { get; set; }
		public string Email { get; set; }
		public string Telefon { get; set; }
		public int GradID { get; set; }

		public object[] GetSqlParamsList() => new object[] { this.Ime, this.Prezime, this.Email, this.Telefon, this.GradID };
	}
}
