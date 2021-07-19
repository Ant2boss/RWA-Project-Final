using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA_Project.Controllers.WebAPI.DataTransferObjects
{
	public class GradDTO
	{
		public int IDGrad { get; set; }
		public string Naziv { get; set; }
		public int DrzavaID { get; set; }
	}
}