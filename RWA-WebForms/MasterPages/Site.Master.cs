using RWA_WebForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RWA_WebForms.MasterPages
{
	public partial class Site : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (this.Session[ProjectConsts.SESSION_ALERT_MESSAGE] != null)
			{
				this.lbAlertMessage.Text = this.Session[ProjectConsts.SESSION_ALERT_MESSAGE].ToString();
				this.Session[ProjectConsts.SESSION_ALERT_MESSAGE] = null;
			}
			else
			{
				this.lbAlertMessage.Text = "";
			}

			if (this.Session[ProjectConsts.SESSION_USER_INFO] == null)
			{
				this.lbKupci.Visible = false;
				this.lbGradovi.Visible = false;
				this.lbDrzave.Visible = false;
				this.btnLogout.Visible = false;
			}
			else
			{
				this.lbLogin.Visible = false;
				this.lbRegister.Visible = false;
			}
		}

		protected void btnLogout_Click(object sender, EventArgs e)
		{
			this.Session.Clear();
			this.Session[ProjectConsts.SESSION_ALERT_MESSAGE] = "Odjavili ste se!";
			this.Response.Redirect("~/Default.aspx");
		}
	}
}