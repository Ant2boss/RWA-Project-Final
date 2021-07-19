using RWA_WebForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace RWA_WebForms.Profile
{
	public class ProfilePageBase : Page
	{
		public bool IsLoggedIn { get; private set; }

		public string AW_CS => System.Configuration.ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

		protected override void OnPreLoad(EventArgs e)
		{
			this.IsLoggedIn = true;

			if (this.Session[ProjectConsts.SESSION_USER_INFO] == null)
			{
				this.IsLoggedIn = false;
				this.Session[ProjectConsts.SESSION_ALERT_MESSAGE] = "Niste prijavljeni";
				this.Response.Redirect("~/Login/Login.aspx");
			}

			base.OnPreLoad(e);
		}
	}
}