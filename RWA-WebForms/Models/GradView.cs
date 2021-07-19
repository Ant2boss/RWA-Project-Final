using RWA_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA_WebForms.Models
{
	public class GradView
	{
		public GradView(Grad grad, string drzavaNaziv)
		{
			Grad = grad;
			DrzavaNaziv = drzavaNaziv;
		}

		public Grad	Grad { get; set; }
		public string DrzavaNaziv { get; set; }
	}
}