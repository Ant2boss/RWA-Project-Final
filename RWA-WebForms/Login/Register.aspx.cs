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
	public partial class Register : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			this._LoginRepo = SqlLoginRepoFactory.GetLoginRepo();
		}

		private ILoginRepo _LoginRepo;

		protected void CustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
		{
			string username = this.tbUsername.Text.Trim();
			string pass = this.tbPassword.Text.Trim();

			try
			{
				this._LoginRepo.CretateLogin(username, pass);
				this.Session[ProjectConsts.SESSION_ALERT_MESSAGE] = "Uspješno stvoren račun!";
				this.Response.Redirect("~/Login/Login.aspx?msg=Success");
			}
			catch
			{
				args.IsValid = false;
			}
		}
	}
}