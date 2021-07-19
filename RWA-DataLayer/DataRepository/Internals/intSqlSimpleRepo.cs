using Microsoft.ApplicationBlocks.Data;
using RWA_DataLayer.DataParsers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWA_DataLayer.DataRepository.Internals
{
	internal class intSqlSimpleRepo<T> : ISimpleRepo<T> where T : ISqlParameterable
	{
		public intSqlSimpleRepo(string ConnectionString, Func<T> Constructor, string ProcPrefix)
		{
			this._iCS = ConnectionString;
			this._iPrefix = ProcPrefix;
			this._Constructor = Constructor;

			string typeName = typeof(T).Name;

			this._PROC_GET_ALL = ProcPrefix + "GetAll" + typeName;
			this._PROC_GET_ONE = ProcPrefix + "Get" + typeName;
			this._PROC_CREATE = ProcPrefix + "Create" + typeName;
			this._PROC_UPDATE = ProcPrefix + "Update" + typeName;
			this._PROC_DELETE = ProcPrefix + "Delete" + typeName;
		}

		private Func<T> _Constructor;

		internal readonly string _iCS;
		internal readonly string _iPrefix;

		private readonly string _PROC_GET_ALL;
		private readonly string _PROC_GET_ONE;
		private readonly string _PROC_CREATE;
		private readonly string _PROC_UPDATE;
		private readonly string _PROC_DELETE;

		public int Create(T ElementData)
		{
			return SqlHelper.ExecuteNonQuery(this._iCS, this._PROC_CREATE, ElementData.GetSqlParamsList().ToArray());
		}
		public int Update(int ID, T ElementData)
		{
			IList<object> param = new List<object>();

			param.Add(ID);
			foreach (object obj in ElementData.GetSqlParamsList())
			{
				param.Add(obj);
			}

			return SqlHelper.ExecuteNonQuery(this._iCS, this._PROC_UPDATE, param.ToArray());
		}
		public int Delete(int ID)
		{
			return SqlHelper.ExecuteNonQuery(this._iCS, this._PROC_DELETE, ID);
		}

		public IEnumerable<T> GetAll()
		{
			return DataParserFactory.ParseDataTable(SqlHelper.ExecuteDataset(this._iCS, this._PROC_GET_ALL).Tables[0], this._Constructor);
		}
		public T Get(int ID)
		{
			DataTable DT = SqlHelper.ExecuteDataset(this._iCS, this._PROC_GET_ONE, ID).Tables[0];

			if (DT.Rows.Count == 0)
			{
				throw new Exception("No such item!");
			}

			return DataParserFactory.ParseDataRow(DT.Rows[0], this._Constructor);
		}

	}
}
