using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWA_DataLayer.DataParsers
{
	[AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
	public sealed class DataColumnAttribute : Attribute
	{
		public DataColumnAttribute(string ColumnName)
		{
			this.ColumnName = ColumnName;
		}

		public string ColumnName { get; }
	}
}
