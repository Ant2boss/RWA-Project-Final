using RWA_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RWA_Project.Models.ViewModels
{
	public class ProizvodVM : IViewModelConverter<Proizvod>
	{
		public int IDProizvod { get; set; }

		[Required(ErrorMessage = "Naziv is requiered")]
		public string Naziv { get; set; }
		
		[Required(ErrorMessage = "Broj proizovda is requiered")]
		public string BrojProizvoda { get; set; }
		
		public string Boja { get; set; }

		[Required(ErrorMessage = "Minimalna kolicina na skaldistu is requiered")]
		public int MinimalnaKolicinaNaSkladistu { get; set; }

		[Required(ErrorMessage = "Cijena bez PDV-a is requiered")]
		[DataType(DataType.Currency)]
		public decimal CijenaBezPDV { get; set; }
		public int PotkategorijaID { get; set; }

		public void SetFrom(Proizvod val)
		{
			this.IDProizvod = val.IDProizvod;
			this.Naziv = val.Naziv;
			this.BrojProizvoda = val.BrojProizvoda;
			this.Boja = val.Boja;
			this.MinimalnaKolicinaNaSkladistu = val.MinimalnaKolicinaNaSkladistu;
			this.CijenaBezPDV = val.CijenaBezPDV;
			this.PotkategorijaID = val.PotkategorijaID;
		}

		public Proizvod ConvertBack() => new Proizvod
		{ 
			IDProizvod = this.IDProizvod,
			Naziv = this.Naziv,
			BrojProizvoda = this.BrojProizvoda,
			Boja = this.Boja,
			MinimalnaKolicinaNaSkladistu = this.MinimalnaKolicinaNaSkladistu,
			CijenaBezPDV = this.CijenaBezPDV,
			PotkategorijaID = this.PotkategorijaID
		};

	}
}