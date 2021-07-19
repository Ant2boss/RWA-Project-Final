using RWA_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RWA_Project.Models.ViewModels
{
	public class GradVM : IViewModelConverter<Grad>
	{
		public int IDGrad { get; set; }

		[Required( ErrorMessage = "Naziv is a requiered field!")]
		public string Naziv { get; set; }
		public int DrzavaID { get; set; }

		public void SetFrom(Grad val)
		{
			this.IDGrad = val.IDGrad;
			this.Naziv = val.Naziv;
			this.DrzavaID = val.DrzavaID;
		}

		public Grad ConvertBack() => new Grad
		{
			IDGrad = this.IDGrad,
			Naziv = this.Naziv,
			DrzavaID = this.DrzavaID
		};
	}
}