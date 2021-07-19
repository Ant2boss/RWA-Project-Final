using RWA_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWA_DataLayer.DataRepository
{
	public interface IRacunRepo : ISimpleRepo<Racun>
	{
		IEnumerable<Racun> GetAllRacunsOfKupac(int IDKupac);
	}
}
