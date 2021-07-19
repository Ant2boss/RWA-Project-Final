using RWA_DataLayer.DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWA_DataLayer.Models
{
	public class Grad : ISqlParameterable
	{
		public int IDGrad { get; set; }
		public string Naziv { get; set; }
		public int DrzavaID { get; set; }

		public object[] GetSqlParamsList() => new object[] { this.Naziv, this.DrzavaID };
	}
}
