using RWA_DataLayer.DataRepository;
using RWA_DataLayer.Models;
using RWA_WebForms.Models;
using RWA_WebForms.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RWA_WebForms.Editors
{
	public partial class DrzavaEditor : ProfilePageBase
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (this.IsLoggedIn)
			{
				this._InitPage();
			}
		}

		ISimpleRepo<Drzava> _DrzavaRepo;

		Drzava _OriginalDrzava;

		private void _InitPage()
		{
			this._DrzavaRepo = SqlRepoFactory.GetDrzavaRepo(this.AW_CS);

			if (this.Session[ProjectConsts.SESSION_DRZAVA_EDITOR] != null)
			{
				this._OriginalDrzava = this.Session[ProjectConsts.SESSION_DRZAVA_EDITOR] as Drzava;
			}
			else
			{
				this._OriginalDrzava = new Drzava();
				this.lbTitle.Text = "Nova država";
			}

			if (!this.IsPostBack)
			{
				this.tbStateName.Text = this._OriginalDrzava.Naziv;
			}
		}

		protected void btnSubmit_Click(object sender, EventArgs e)
		{
			if (this._OriginalDrzava.IDDrzava != 0)
			{
				this._DrzavaRepo.Update(this._OriginalDrzava.IDDrzava, this._ParseDrzava());

				this.Session[ProjectConsts.SESSION_ALERT_MESSAGE] = "Država uspješno uređena!";
			}
			else
			{
				this._DrzavaRepo.Create(this._ParseDrzava());

				this.Session[ProjectConsts.SESSION_ALERT_MESSAGE] = "Država uspješno dodana!";
			}
			this.Session[ProjectConsts.SESSION_DRZAVA_EDITOR] = null;

			this.Response.Redirect("~/Profile/Drzave.aspx");
		}
		protected void btnCancel_Click(object sender, EventArgs e)
		{
			this.Session[ProjectConsts.SESSION_DRZAVA_EDITOR] = null;
			this.Response.Redirect("~/Profile/Drzave.aspx");
		}

		private Drzava _ParseDrzava()
		{
			return new Drzava
			{
				Naziv = this.tbStateName.Text.Trim()
			};
		}
	}
}