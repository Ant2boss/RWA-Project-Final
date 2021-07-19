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
	public partial class Kupci : ProfilePageBase
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (this.IsLoggedIn)
			{
				if (this.IsPostBack)
				{
					this._SS_CurrentPage = Math.Max(int.Parse(this.tbPageNum.Text) - 1, 0);
					this._SS_CurrentAmount = Math.Max(1, Math.Min(int.Parse(this.tbKupacNum.Text), 50));
				}

				this._KupacRepo = SqlRepoFactory.GetKupacRepo(this.AW_CS);
				this._GradRepo = SqlRepoFactory.GetGradRepo(this.AW_CS);
				this._DrzavaRepo = SqlRepoFactory.GetDrzavaRepo(this.AW_CS);

				if (!this.IsPostBack)
				{
					this._InitDDL();
				}
			}
		}

		protected override void OnPreRender(EventArgs e)
		{
			if (this.IsLoggedIn)
			{ 
				this._LoadPage();
			}

			base.OnPreRender(e);
		}

		private ISimpleRepo<Kupac> _KupacRepo;
		private ISimpleRepo<Grad> _GradRepo;
		private ISimpleRepo<Drzava> _DrzavaRepo;
		private IList<KupacView> _KupacList;
		private ListPager<KupacView> _KupacPager;

		private readonly string SESSION_PAGE = "s-page";
		private readonly string SESSION_AMOUNT = "s-amount";

		private int _SS_CurrentPage
		{
			get
			{
				if (this.Session[SESSION_PAGE] == null)
				{
					this.Session[SESSION_PAGE] = 0;
				}

				return (int)this.Session[SESSION_PAGE];
			}
			set
			{
				this.Session[SESSION_PAGE] = value;
			}
		}
		private int _SS_CurrentAmount
		{
			get
			{
				if (this.Session[SESSION_AMOUNT] == null)
				{
					this.Session[SESSION_AMOUNT] = 10;
				}

				return (int)this.Session[SESSION_AMOUNT];
			}
			set
			{
				this.Session[SESSION_AMOUNT] = value;
			}
		}

		private void _InitDDL()
		{
			this.ddlStatesFilter.Items.Clear();
			this.ddlStatesFilter.Items.Add(new ListItem("--Bez filtera drzave--", "-1"));

			foreach (Drzava d in this._DrzavaRepo.GetAll())
			{
				this.ddlStatesFilter.Items.Add(new ListItem(d.Naziv, d.IDDrzava.ToString()));
			}

			this._FillGradovi(this._GradRepo.GetAll());

		}

		private void _FillGradovi(IEnumerable<Grad> gradEnum)
		{
			this.ddlCityFilter.Items.Clear();
			this.ddlCityFilter.Items.Add(new ListItem("--Bez filtera grada--", "-1"));

			foreach (Grad g in gradEnum)
			{
				this.ddlCityFilter.Items.Add(new ListItem(g.Naziv, g.IDGrad.ToString()));
			}
		}

		private void _LoadPage()
		{
			IDictionary<int, Grad> gradDict = this._GradRepo.GetAll().ToDictionary((grad) => grad.IDGrad);

			this._KupacList = this._KupacRepo.GetAll().Select(kup => new KupacView(kup, gradDict[kup.GradID].Naziv)).ToList();
			this._FilterAndSortKupacList(gradDict);
			this._KupacPager = new ListPager<KupacView>(this._KupacList);

			this._KupacPager.AmountPerPage = this._SS_CurrentAmount;
			this._KupacPager.Page = this._SS_CurrentPage;

			this.lbMaxPages.Text = $" Max({this._KupacPager.LastPage}):";
			this.tbPageNum.Text = (this._KupacPager.Page + 1).ToString();
			this.tbKupacNum.Text = this._KupacPager.AmountPerPage.ToString();

			this.MyRepeater.DataSource = this._KupacPager.GetList();
			this.MyRepeater.DataBind();
		}

		private void _FilterAndSortKupacList(IDictionary<int, Grad> gradDict)
		{
			int IDDrzava = int.Parse(this.ddlStatesFilter.SelectedValue);
			int IDGrad = int.Parse(this.ddlCityFilter.SelectedValue);

			if (IDDrzava != -1)
			{
				this._KupacList = this._KupacList.Where(el => gradDict[el.Kupac.GradID].DrzavaID == IDDrzava).ToList();

				if (IDGrad != -1)
				{
					this._KupacList = this._KupacList.Where(el => el.Kupac.GradID == IDGrad).ToList();
				}
			}
			else if (IDGrad != -1)
			{
				this._KupacList = this._KupacList.Where(el => el.Kupac.GradID == IDGrad).ToList();
			}

			if (this.rbSortFirstName.Checked)
			{
				List<KupacView> temp = this._KupacList.ToList();
				temp.Sort((k1, k2) => k1.Kupac.Ime.CompareTo(k2.Kupac.Ime));
				this._KupacList = temp;
			}
			else if (this.rbSortLastName.Checked)
			{
				List<KupacView> temp = this._KupacList.ToList();
				temp.Sort((k1, k2) => k1.Kupac.Prezime.CompareTo(k2.Kupac.Prezime));
				this._KupacList = temp;
			}
		}

		protected void lbtnEdit_Click(object sender, EventArgs e)
		{
			if (sender is LinkButton linkBtn)
			{
				int IDKupac = int.Parse(linkBtn.CommandArgument);

				this.Session[ProjectConsts.SESSION_KUPAC_EDITOR] = this._KupacRepo.Get(IDKupac);
				this.Response.Redirect("~/Editors/KupacEditor.aspx");
			}
		}

		protected void lbtnDelete_Click(object sender, EventArgs e)
		{
			if (sender is LinkButton linkBtn)
			{
				int IDKupac = int.Parse(linkBtn.CommandArgument);

				try
				{
					this._KupacRepo.Delete(IDKupac);
					this.Session[ProjectConsts.SESSION_ALERT_MESSAGE] = "Kupac uspješno obrisan!";
				}
				catch
				{
					this.Session[ProjectConsts.SESSION_ALERT_MESSAGE] = "Brisanje nije uspjelo!\nKupac ima računa!";
				}


				this.Response.Redirect("~/Profile/Kupci.aspx");
			}
		}

		protected void ddlStatesFilter_SelectedIndexChanged(object sender, EventArgs e)
		{
			int IDDrzava = int.Parse(this.ddlStatesFilter.SelectedValue);

			if (IDDrzava != -1)
			{
				this._FillGradovi(this._GradRepo.GetAll().Where(g => g.DrzavaID == IDDrzava));
			}
			else
			{
				this._FillGradovi(this._GradRepo.GetAll());
			}

		}
	}
}