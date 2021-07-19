using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RWA_DataLayer.DataParsers
{
	public static class DataParserFactory
	{
		public static T ParseDataRow<T>(DataRow dataRow, Func<T> constructor)
		{
			T Result = constructor.Invoke();

			Type type = Result.GetType();
			foreach (PropertyInfo propInfo in type.GetProperties())
			{
				bool HasAttribute = false;

				foreach (Attribute attr in propInfo.GetCustomAttributes())
				{
					if (attr is DataColumnAttribute tColumn && dataRow.Table.Columns.Contains(tColumn.ColumnName) && dataRow[tColumn.ColumnName] != DBNull.Value)
					{
						propInfo.SetValue(Result, dataRow[tColumn.ColumnName]);
						HasAttribute = true;
					}
				}

				if (!HasAttribute && dataRow.Table.Columns.Contains(propInfo.Name) && dataRow[propInfo.Name] != DBNull.Value)
				{
					propInfo.SetValue(Result, dataRow[propInfo.Name]);
				}
			}

			return Result;
		}

		public static IEnumerable<T> ParseDataTable<T>(DataTable dataTable, Func<T> constructor)
		{
			foreach (DataRow row in dataTable.Rows)
			{
				yield return ParseDataRow(row, constructor);
			}
		}
	}
}
