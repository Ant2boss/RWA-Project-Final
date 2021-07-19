using RWA_DataLayer.DataRepository;
using RWA_Project.Controllers.WebAPI.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RWA_Project.Controllers.WebAPI
{
    public class StavkaAPIController : ApiController
    {
        private string _cs = System.Configuration.ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        //Disabled --> Turns out 120000+ products is a very big amount of stuff to load in
		//[HttpGet]
		//public IHttpActionResult Get()
		//{
  //          IEnumerable<StavkaDTO> data = SqlRepoFactory.GetStavkaRepo(this._cs).GetAll().Select(el =>
  //          {
  //              StavkaDTO stvk = new StavkaDTO();
  //              stvk.SetFrom(el);
  //              return stvk;
  //          });

		//	return this.Ok(data);
		//}
		[HttpGet]
        public IHttpActionResult GetStavkeOfRacun(int IDRacun)
        {
            IEnumerable<StavkaDTO> data = (SqlRepoFactory.GetStavkaRepo(this._cs) as IStavkaRepo)
                .GetAllStavkasOfRacun(IDRacun)
                .Select(el =>
                {
                    StavkaDTO stvk = new StavkaDTO();
                    stvk.SetFrom(el);
                    return stvk;
                });

            return this.Ok(data);
        }
    }
}
