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
	public partial class KupacEditor : ProfilePageBase
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (this.IsLoggedIn)
			{
				this._InitPage();

				if (!this.IsPostBack)
				{
					this._FillForm();
				}
			}
		}

		ISimpleRepo<Kupac> _KupacRepo;
		ISimpleRepo<Grad> _GradRepo;

		Kupac _OriginalKupac;

		private void _InitPage()
		{
			this._KupacRepo = SqlRepoFactory.GetKupacRepo(this.AW_CS);
			this._GradRepo = SqlRepoFactory.GetGradRepo(this.AW_CS);

			if (this.Session[ProjectConsts.SESSION_KUPAC_EDITOR] != null)
			{
				this._OriginalKupac = this.Session[ProjectConsts.SESSION_KUPAC_EDITOR] as Kupac;
			}
			else
			{
				this._OriginalKupac = new Kupac();
				this.lbTitle.Text = "Novi kupac";
			}
		}

		private void _FillForm()
		{
			this.tbFirstName.Text = this._OriginalKupac.Ime;
			this.tbLastName.Text = this._OriginalKupac.Prezime;
			this.tbEmail.Text = this._OriginalKupac.Email;
			this.tbPhone.Text = this._OriginalKupac.Telefon;

			this.ddlGradovi.Items.Clear();
			foreach (Grad g in this._GradRepo.GetAll())
			{
				this.ddlGradovi.Items.Add(new ListItem(g.Naziv, g.IDGrad.ToString()));
			}

			this.ddlGradovi.SelectedValue = this._OriginalKupac.GradID.ToString();
		}

		private Kupac _ParseKupac()
		{
			return new Kupac
			{
				Ime = this.tbFirstName.Text.Trim(),
				Prezime = this.tbLastName.Text.Trim(),
				Email = this.tbEmail.Text.Trim(),
				Telefon = this.tbPhone.Text.Trim(),
				GradID = int.Parse(this.ddlGradovi.SelectedValue)
			};
		}

		protected void btnSubmit_Click(object sender, EventArgs e)
		{
			if (this._OriginalKupac.IDKupac != 0)
			{
				this._KupacRepo.Update(this._OriginalKupac.IDKupac, this._ParseKupac());

				this.Session[ProjectConsts.SESSION_KUPAC_EDITOR] = null;
				this.Session[ProjectConsts.SESSION_ALERT_MESSAGE] = "Kupac uspješno uređen!";
			}
			else
			{
				this._KupacRepo.Create(this._ParseKupac());

				this.Session[ProjectConsts.SESSION_KUPAC_EDITOR] = null;
				this.Session[ProjectConsts.SESSION_ALERT_MESSAGE] = "Kupac uspješno stvoren!";
			}

			this.Response.Redirect("~/Profile/Kupci.aspx");
		}
		protected void btnCancel_Click(object sender, EventArgs e)
		{
			this.Session[ProjectConsts.SESSION_KUPAC_EDITOR] = null;
			this.Response.Redirect("~/Profile/Kupci.aspx");
		}
	}
}