using RWA_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA_WebForms.Models
{
	public class KupacView
	{
		public KupacView(Kupac kupac, string Grad)
		{
			this.Kupac = kupac;
			this.GradName = Grad;
		}

		public Kupac Kupac { get; set; }
		public string GradName { get; set; }
	}
}