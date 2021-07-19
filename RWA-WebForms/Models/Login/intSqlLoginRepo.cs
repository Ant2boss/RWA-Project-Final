using Microsoft.ApplicationBlocks.Data;
using RWA_DataLayer.DataParsers;
using RWA_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWA_WebForms.Models.Login
{
	internal class intSqlLoginRepo : ILoginRepo
	{
		private readonly string CS = System.Configuration.ConfigurationManager.ConnectionStrings["userAuth"].ConnectionString;

		private readonly string PROC_CREATE_USER = "CreateUser";
		private readonly string PROC_CHECK_USER = "CheckUser";
		private readonly string PROC_GET_USER = "GetUser";
		private readonly string PROC_DELETE_USER = "DeleteUser";

		public const int INVALID_USER_ID = -1;

		public int CretateLogin(string Username, string Password)
		{
			SqlParameter[] parameters = new SqlParameter[3]
			{ 
				new SqlParameter("@Username", Username),
				new SqlParameter("@Password", EncryptionFactory.ComputeSha256Hash(Password)),
				new SqlParameter("@IDUser", SqlDbType.Int)
			};

			parameters[2].Direction = ParameterDirection.Output;

			SqlHelper.ExecuteNonQuery(this.CS, CommandType.StoredProcedure, this.PROC_CREATE_USER, parameters);

			return (int)parameters[2].Value;
		}

		public int CheckLogin(string Username, string Password)
		{
			SqlParameter[] parameters = new SqlParameter[3]
			{
				new SqlParameter("@Username", Username),
				new SqlParameter("@Password", EncryptionFactory.ComputeSha256Hash(Password)),
				new SqlParameter("@IDUser", SqlDbType.Int)
			};

			parameters[2].Direction = ParameterDirection.Output;

			SqlHelper.ExecuteNonQuery(this.CS, CommandType.StoredProcedure, this.PROC_CHECK_USER, parameters);

			return (int)parameters[2].Value;
		}

		public int DeleteLogin(int IDUser)
		{
			return SqlHelper.ExecuteNonQuery(this.CS, this.PROC_DELETE_USER,IDUser);
		}

		public UserInfo GetLoginUser(string Username, string Password)
		{
			int IDUser = this.CheckLogin(Username, Password);

			if (IDUser == INVALID_USER_ID)
			{
				throw new Exception("No such login!");
			}

			DataRow DR = SqlHelper.ExecuteDataset(this.CS, this.PROC_GET_USER, IDUser).Tables[0].Rows[0];

			return DataParserFactory.ParseDataRow(DR, () => new UserInfo());
		}
	}
}
