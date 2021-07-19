using RWA_DataLayer.DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWA_DataLayer.Models
{
	public class Proizvod : ISqlParameterable
	{
		public int IDProizvod { get; set; }
		public string Naziv { get; set; }
		public string BrojProizvoda { get; set; }
		public string Boja { get; set; }
		public int MinimalnaKolicinaNaSkladistu{ get; set; }
		public decimal CijenaBezPDV { get; set; }
		public int PotkategorijaID { get; set; }

		public object[] GetSqlParamsList() => new object[] { this.Naziv, this.BrojProizvoda, this.Boja, this.MinimalnaKolicinaNaSkladistu, this.CijenaBezPDV, this.PotkategorijaID };
	}
}
