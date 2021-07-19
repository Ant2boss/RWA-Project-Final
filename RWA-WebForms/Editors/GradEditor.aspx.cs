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
	public partial class GradEditor : ProfilePageBase
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (this.IsLoggedIn)
			{
				this._InitPage();

			}
		}

		ISimpleRepo<Grad> _GradRepo;
		ISimpleRepo<Drzava> _DrzavaRepo;

		Grad _OriginalGrad;

		private void _InitPage()
		{
			this._GradRepo = SqlRepoFactory.GetGradRepo(this.AW_CS);
			this._DrzavaRepo = SqlRepoFactory.GetDrzavaRepo(this.AW_CS);

			if (this.Session[ProjectConsts.SESSION_GRAD_EDITOR] != null)
			{
				this._OriginalGrad = this.Session[ProjectConsts.SESSION_GRAD_EDITOR] as Grad;
			}
			else
			{
				this._OriginalGrad = new Grad();
				this.lbTitle.Text = "Novi grad";
			}

			if (!this.IsPostBack)
			{
				this.tbCityName.Text = this._OriginalGrad.Naziv;

				this.ddlDrzave.Items.Clear();
				foreach (Drzava d in this._DrzavaRepo.GetAll())
				{
					this.ddlDrzave.Items.Add(new ListItem(d.Naziv, d.IDDrzava.ToString()));
				}

				this.ddlDrzave.SelectedValue = this._OriginalGrad.DrzavaID.ToString();
			}

		}

		protected void btnSubmit_Click(object sender, EventArgs e)
		{
			if (this._OriginalGrad.IDGrad != 0)
			{ 
				this._GradRepo.Update(this._OriginalGrad.IDGrad, this._ParseGrad());

				this.Session[ProjectConsts.SESSION_ALERT_MESSAGE] = "Grad uspješno ažuriran!";
			}
			else
			{
				this._GradRepo.Create(this._ParseGrad());

				this.Session[ProjectConsts.SESSION_ALERT_MESSAGE] = "Grad uspješno dodan!";
			}

			this.Session[ProjectConsts.SESSION_GRAD_EDITOR] = null;
			this.Response.Redirect("~/Profile/Gradovi.aspx");
		}

		protected void btnCancel_Click(object sender, EventArgs e)
		{
			this.Session[ProjectConsts.SESSION_GRAD_EDITOR] = null;
			this.Response.Redirect("~/Profile/Gradovi.aspx");
		}

		private Grad _ParseGrad()
		{
			return new Grad
			{
				Naziv = this.tbCityName.Text.Trim(),
				DrzavaID = int.Parse(this.ddlDrzave.SelectedValue)
			};
		}
	}
}