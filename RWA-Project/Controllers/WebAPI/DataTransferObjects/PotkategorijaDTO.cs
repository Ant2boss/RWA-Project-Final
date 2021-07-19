using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA_Project.Controllers.WebAPI.DataTransferObjects
{
	public class PotkategorijaDTO
	{
		public int IDPotkategorija { get; set; }
		public string Naziv { get; set; }
		public int KategorijaID { get; set; }
	}
}