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
	public partial class Gradovi : ProfilePageBase
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (this.IsLoggedIn)
			{
				this._InitPage();
			}
		}

		private ISimpleRepo<Grad> _GradRepo;
		private ISimpleRepo<Drzava> _DrzavaRepo;

		private IList<GradView> _GradList;

		private void _InitPage()
		{
			this._GradRepo = SqlRepoFactory.GetGradRepo(this.AW_CS);
			this._DrzavaRepo = SqlRepoFactory.GetDrzavaRepo(this.AW_CS);

			if (!this.IsPostBack)
			{
				this._FillDDL();
			}

			this._FilterGradList();

			this.Repeater.DataSource = this._GradList;
			this.Repeater.DataBind();

		}

		private void _FilterGradList()
		{
			int IDDrzava = int.Parse(this.ddlStatesFilter.SelectedValue);

			IDictionary<int, Drzava> drzavaDict = this._DrzavaRepo.GetAll().ToDictionary(drzava => drzava.IDDrzava);
			IEnumerable<Grad> temp;

			if (IDDrzava != -1)
			{
				temp = this._GradRepo.GetAll().Where(g => g.DrzavaID == IDDrzava);
			}
			else
			{
				temp = this._GradRepo.GetAll();
			}

			this._GradList = temp.Select(grad => new GradView(grad, drzavaDict[grad.DrzavaID].Naziv)).ToList();
		}

		private void _FillDDL()
		{
			this.ddlStatesFilter.Items.Clear();
			this.ddlStatesFilter.Items.Add(new ListItem("--Bez filtera drzave--", "-1"));

			foreach (Drzava d in this._DrzavaRepo.GetAll())
			{
				this.ddlStatesFilter.Items.Add(new ListItem(d.Naziv, d.IDDrzava.ToString()));
			}
		}

		protected void btnEdit_Click(object sender, EventArgs e)
		{
			if (sender is LinkButton linkBtn)
			{
				int IDGrad = int.Parse(linkBtn.CommandArgument);

				this.Session[ProjectConsts.SESSION_GRAD_EDITOR] = this._GradRepo.Get(IDGrad);
				this.Response.Redirect("~/Editors/GradEditor.aspx");
			}
		}
		protected void btnDelete_Click(object sender, EventArgs e)
		{
			if (sender is LinkButton linkBtn)
			{
				int IDGrad = int.Parse(linkBtn.CommandArgument);

				try
				{
					this._GradRepo.Delete(IDGrad);
					this.Session[ProjectConsts.SESSION_ALERT_MESSAGE] = "Grad uspješno obrisan!";
				}
				catch
				{
					this.Session[ProjectConsts.SESSION_ALERT_MESSAGE] = "Brisanje nije uspjelo!\nGrad ima kupaca!";
				}

				this.Response.Redirect("~/Profile/Gradovi.aspx");
			}
		}
	}
}