using RWA_DataLayer.Models;
using RWA_WebForms.Models;
using RWA_WebForms.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RWA_WebForms.Login
{
	public partial class Login : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			this._LoginRepo = SqlLoginRepoFactory.GetLoginRepo();
		}

		ILoginRepo _LoginRepo;

		protected void CustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
		{
			try
			{
				this.Session[ProjectConsts.SESSION_USER_INFO] = this._LoginRepo.GetLoginUser(this.tbUsername.Text, this.tbPassword.Text);
				this.Response.Redirect("~/Profile/Kupci.aspx");
			}
			catch
			{
				args.IsValid = false;
			}
		}
	}
}