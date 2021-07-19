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
    public class GradAPIController : ApiController
    {
        private string _cs = System.Configuration.ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        [HttpGet]
        public IHttpActionResult Get()
        {
            IEnumerable<GradDTO> data = AutoMapperConfig.GradMapper.Map<IEnumerable<GradDTO>>(
                SqlRepoFactory.GetGradRepo(this._cs).GetAll()
                );

            return this.Ok(data);
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            GradDTO data = AutoMapperConfig.GradMapper.Map<GradDTO>(
                SqlRepoFactory.GetGradRepo(this._cs).Get(id)
                );

            return this.Ok(data);
        }
    }
}
