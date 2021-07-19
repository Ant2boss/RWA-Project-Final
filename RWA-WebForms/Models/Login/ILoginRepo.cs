using RWA_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWA_WebForms.Models.Login
{
	public interface ILoginRepo
	{
		int CretateLogin(string Username, string Password);

		int CheckLogin(string Username, string Password);

		int DeleteLogin(int IDUser);

		UserInfo GetLoginUser(string Username, string Password);
	}
}
