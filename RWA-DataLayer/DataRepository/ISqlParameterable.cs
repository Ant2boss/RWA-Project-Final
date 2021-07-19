using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWA_DataLayer.DataRepository
{
	public interface ISqlParameterable
	{
		object[] GetSqlParamsList();
	}
}
