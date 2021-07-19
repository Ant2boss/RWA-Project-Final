using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWA_WebForms.Models.Login
{
	public class UserInfo
	{
		public UserInfo()
		{
		}
		public UserInfo(int IDUser, string Username)
		{
			this.IDUser = IDUser;
			this.Username = Username;
		}

		public int IDUser { get; set; }
		public string Username { get; set; }

		public override string ToString() => $"{this.Username}";
		public override bool Equals(object obj)
		{
			return obj is UserInfo info &&
				   IDUser == info.IDUser;
		}
		public override int GetHashCode()
		{
			return 947626171 + IDUser.GetHashCode();
		}
	}
}
