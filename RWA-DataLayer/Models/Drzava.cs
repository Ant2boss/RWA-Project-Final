using RWA_DataLayer.DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWA_DataLayer.Models
{
	public class Drzava : ISqlParameterable
	{
		public int IDDrzava { get; set; }
		public string Naziv { get; set; }

		public object[] GetSqlParamsList() => new object[] { this.Naziv };
	}
}
