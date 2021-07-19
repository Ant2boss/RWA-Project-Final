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
	internal class intSqlRacunRepo : intSqlSimpleRepo<Racun>, IRacunRepo
	{
		public intSqlRacunRepo(string ConnectionString, Func<Racun> Constructor, string ProcPrefix) : base(ConnectionString, Constructor, ProcPrefix)
		{
			this.PROC_GET_RACUNI_OF_KUPAC = this._iPrefix + "GetRacuniOfKupac";
		}

		private readonly string PROC_GET_RACUNI_OF_KUPAC;

		public IEnumerable<Racun> GetAllRacunsOfKupac(int IDKupac)
		{
			return DataParserFactory.ParseDataTable(
				SqlHelper.ExecuteDataset(this._iCS, this.PROC_GET_RACUNI_OF_KUPAC, IDKupac).Tables[0],
				() => new Racun());
		}
	}
}
