using RWA_DataLayer.DataRepository;
using RWA_DataLayer.Models;
using RWA_WebForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RWA_WebForms.Profile
{
	public partial class Drzave : ProfilePageBase
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (this.IsLoggedIn)
			{
				this._InitPage();
			}
		}

		ISimpleRepo<Drzava> _DrzavaRepo;

		IList<Drzava> _DrzavaList;

		private void _InitPage()
		{
			this._DrzavaRepo = SqlRepoFactory.GetDrzavaRepo(this.AW_CS);

			this._DrzavaList = this._DrzavaRepo.GetAll().ToList();

			this.Repeater.DataSource = this._DrzavaList;
			this.Repeater.DataBind();
		}

		protected void btnEdit_Click(object sender, EventArgs e)
		{
			if (sender is LinkButton linkBtn)
			{
				int IDDrzava = int.Parse(linkBtn.CommandArgument);

				this.Session[ProjectConsts.SESSION_DRZAVA_EDITOR] = this._DrzavaRepo.Get(IDDrzava);
				this.Response.Redirect("~/Editors/DrzavaEditor.aspx");
			}
		}

		protected void btnDelete_Click(object sender, EventArgs e)
		{
			if (sender is LinkButton linkBtn)
			{
				int IDDrzava = int.Parse(linkBtn.CommandArgument);

				try
				{
					this._DrzavaRepo.Delete(IDDrzava);
					this.Session[ProjectConsts.SESSION_ALERT_MESSAGE] = "Država uspješno obrisana!";
				}
				catch
				{
					this.Session[ProjectConsts.SESSION_ALERT_MESSAGE] = "Brisanje nije uspjelo!\nDržava ima gradove!";
				}

				this.Response.Redirect("~/Profile/Drzave.aspx");
			}
		}
	}
}