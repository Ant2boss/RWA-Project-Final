using AutoMapper;
using RWA_DataLayer.Models;
using RWA_Project.Controllers.WebAPI.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA_Project
{
	public static class AutoMapperConfig
	{
		public static IMapper DrzavaMapper { get; set; }
		public static IMapper GradMapper { get; set; }
		public static IMapper KategorijaMapper { get; set; }
		public static IMapper KomercijalistMapper { get; set; }
		public static IMapper KreditnaKarticaMapper { get; set; }
		public static IMapper KupacMapper { get; set; }
		public static IMapper PotkategorijaMapper { get; set; }
		public static IMapper ProizvodMapper { get; set; }
		public static IMapper RacunMapper { get; set; }
		public static IMapper StavkaMapper { get; set; }

		public static void Init()
		{
			DrzavaMapper = (new MapperConfiguration(cfg => cfg.CreateMap<Drzava, DrzavaDTO>())).CreateMapper();
			GradMapper = (new MapperConfiguration(cfg => cfg.CreateMap<Grad, GradDTO>())).CreateMapper();
			KategorijaMapper = (new MapperConfiguration(cfg => cfg.CreateMap<Kategorija, KategorijaDTO>())).CreateMapper();
			KomercijalistMapper = (new MapperConfiguration(cfg => cfg.CreateMap<Komercijalist, KomercijalistDTO>())).CreateMapper();
			KreditnaKarticaMapper = (new MapperConfiguration(cfg => cfg.CreateMap<KreditnaKartica, KreditnaKarticaDTO>())).CreateMapper();
			KupacMapper = (new MapperConfiguration(cfg => cfg.CreateMap<Kupac, KupacDTO>())).CreateMapper();
			PotkategorijaMapper = (new MapperConfiguration(cfg => cfg.CreateMap<Potkategorija, PotkategorijaDTO>())).CreateMapper();
			ProizvodMapper = (new MapperConfiguration(cfg => cfg.CreateMap<Proizvod, ProizvodDTO>())).CreateMapper();
			RacunMapper = (new MapperConfiguration(cfg => cfg.CreateMap<Racun, RacunDTO>())).CreateMapper();
			StavkaMapper = (new MapperConfiguration(cfg => cfg.CreateMap<Stavka, StavkaDTO>())).CreateMapper();
		}
	}
}