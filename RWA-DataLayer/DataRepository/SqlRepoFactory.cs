using RWA_DataLayer.DataRepository.Internals;
using RWA_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWA_DataLayer.DataRepository
{
	public static class SqlRepoFactory
	{
		private const string PROC_PREFIX = "RWA_AK_";

		public static ISimpleRepo<Drzava> GetDrzavaRepo(string ConnectionString) => new intSqlSimpleRepo<Drzava>(
			ConnectionString, 
			() => new Drzava(), 
			PROC_PREFIX);
		public static ISimpleRepo<Grad> GetGradRepo(string ConnectionString) => new intSqlSimpleRepo<Grad>(
			ConnectionString, 
			() => new Grad(), 
			PROC_PREFIX);
		public static ISimpleRepo<Kategorija> GetKategorijaRepo(string ConnectionString) => new intSqlSimpleRepo<Kategorija>(
			ConnectionString, 
			() => new Kategorija(), 
			PROC_PREFIX);
		public static ISimpleRepo<Komercijalist> GetKomercijalistRepo(string ConnectionString) => new intSqlSimpleRepo<Komercijalist>(
			ConnectionString, 
			() => new Komercijalist(), 
			PROC_PREFIX);
		public static ISimpleRepo<KreditnaKartica> GetKreditnaKarticaRepo(string ConnectionString) => new intSqlSimpleRepo<KreditnaKartica>(
			ConnectionString, 
			() => new KreditnaKartica(), 
			PROC_PREFIX);
		public static ISimpleRepo<Kupac> GetKupacRepo(string ConnectionString) => new intSqlSimpleRepo<Kupac>(
			ConnectionString,
			() => new Kupac(),
			PROC_PREFIX);
		public static ISimpleRepo<Potkategorija> GetPotkategorijaRepo(string ConnectionString) => new intSqlSimpleRepo<Potkategorija>(
			ConnectionString, 
			() => new Potkategorija(), 
			PROC_PREFIX);
		public static ISimpleRepo<Proizvod> GetProizvodRepo(string ConnectionString) => new intSqlSimpleRepo<Proizvod>(
			ConnectionString, 
			() => new Proizvod(), 
			PROC_PREFIX);
		public static ISimpleRepo<Racun> GetRacunRepo(string ConnectionString) => new intSqlRacunRepo(
			ConnectionString,
			() => new Racun(),
			PROC_PREFIX);
		public static ISimpleRepo<Stavka> GetStavkaRepo(string ConnectionString) => new intSqlStavkaRepo(
			ConnectionString,
			() => new Stavka(),
			PROC_PREFIX);

	}
}
