using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA_Project.Controllers.WebAPI.DataTransferObjects
{
	public class ProizvodDTO
	{
		public int IDProizvod { get; set; }
		public string Naziv { get; set; }
		public string BrojProizvoda { get; set; }
		public string Boja { get; set; }
		public int MinimalnaKolicinaNaSkladistu { get; set; }
		public decimal CijenaBezPDV { get; set; }
		public int PotkategorijaID { get; set; }
	}
}