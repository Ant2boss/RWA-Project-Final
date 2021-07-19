using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA_Project.Controllers.WebAPI.DataTransferObjects
{
	public class KomercijalistDTO
	{
		public int IDKomercijalist { get; set; }
		public string Ime { get; set; }
		public string Prezime { get; set; }
		public bool StalniZaposlenik { get; set; }
	}
}