using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA_Project.Controllers.WebAPI.DataTransferObjects
{
	public class KreditnaKarticaDTO
	{
		public int IDKreditnaKartica { get; set; }
		public string Tip { get; set; }
		public string Broj { get; set; }
		public int IstekMjesec { get; set; }
		public int IstekGodina { get; set; }
	}
}