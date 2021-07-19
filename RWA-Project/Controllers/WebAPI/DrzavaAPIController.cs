using RWA_DataLayer.DataRepository;
using RWA_DataLayer.Models;
using RWA_Project.Controllers.WebAPI.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RWA_Project.Controllers.WebAPI
{
    public class DrzavaAPIController : ApiController
    {
        private string _cs = System.Configuration.ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        [HttpGet]
        public IHttpActionResult Get()
        {
            IEnumerable<DrzavaDTO> data = AutoMapperConfig.DrzavaMapper.Map<IEnumerable<DrzavaDTO>>(
                SqlRepoFactory.GetDrzavaRepo(this._cs).GetAll()
                );

            return this.Ok(data);
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            DrzavaDTO data = AutoMapperConfig.DrzavaMapper.Map<DrzavaDTO>(
                SqlRepoFactory.GetDrzavaRepo(this._cs).Get(id)
                );

            return this.Ok(data);
        }
    }
}
