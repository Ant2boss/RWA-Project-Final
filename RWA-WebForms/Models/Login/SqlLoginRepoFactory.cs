using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA_WebForms.Models.Login
{
	public static class SqlLoginRepoFactory
	{
		public static ILoginRepo GetLoginRepo() => new intSqlLoginRepo();
	}
}