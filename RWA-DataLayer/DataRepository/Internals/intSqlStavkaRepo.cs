using Microsoft.ApplicationBlocks.Data;
using RWA_DataLayer.DataParsers;
using RWA_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWA_DataLayer.DataRepository.Internals
{
	internal class intSqlStavkaRepo : intSqlSimpleRepo<Stavka>, IStavkaRepo
	{
		public intSqlStavkaRepo(string ConnectionString, Func<Stavka> Constructor, string ProcPrefix) : base(ConnectionString, Constructor, ProcPrefix)
		{
			this.PROC_GET_STAVKE_OF_RACUN = this._iPrefix + "GetStavkeOfRacun";
		}

		private readonly string PROC_GET_STAVKE_OF_RACUN;

		public IEnumerable<Stavka> GetAllStavkasOfRacun(int IDRacun)
		{
			return DataParserFactory.ParseDataTable(
				SqlHelper.ExecuteDataset(this._iCS, this.PROC_GET_STAVKE_OF_RACUN, IDRacun).Tables[0], 
				() => new Stavka());
		}
	}
}
