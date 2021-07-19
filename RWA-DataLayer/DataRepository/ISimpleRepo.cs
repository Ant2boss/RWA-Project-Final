using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWA_DataLayer.DataRepository
{
	public interface ISimpleRepo<T>
	{
		IEnumerable<T> GetAll();
		T Get(int ID);

		int Create(T ElementData);
		int Update(int ID, T ElementData);
		int Delete(int ID);
	}
}
