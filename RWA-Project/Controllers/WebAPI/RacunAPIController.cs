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
    public class RacunAPIController : ApiController
    {
        private string _cs = System.Configuration.ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        [HttpGet]
        public IHttpActionResult Get()
        {
            IEnumerable<RacunDTO> data = AutoMapperConfig.RacunMapper.Map<IEnumerable<RacunDTO>>(
                SqlRepoFactory.GetRacunRepo(this._cs).GetAll()
                );

            return this.Ok(data);
        }
        [HttpGet]
        public IHttpActionResult GetAllRacuniOfKupac(int IDKupac)
        {
            IEnumerable<RacunDTO> data = AutoMapperConfig.RacunMapper.Map<IEnumerable<RacunDTO>>(
                (SqlRepoFactory.GetRacunRepo(this._cs) as IRacunRepo).GetAllRacunsOfKupac(IDKupac)
                );

            return this.Ok(data);
        }
    }
}
