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
    public class ProizvodAPIController : ApiController
    {
        private string _cs = System.Configuration.ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        [HttpGet]
        public IHttpActionResult GetProizvodi()
        {
            ISimpleRepo<Proizvod> ProizvodRepo = SqlRepoFactory.GetProizvodRepo(this._cs);

            IEnumerable<Proizvod> proizvods = ProizvodRepo.GetAll();
            IEnumerable<ProizvodDTO> proizvodsDTO = AutoMapperConfig.ProizvodMapper.Map<IEnumerable<ProizvodDTO>>(proizvods);

            return this.Ok(proizvodsDTO);
        } 
        [HttpGet]
        public IHttpActionResult GetProizvodi(int id)
        {
            ISimpleRepo<Proizvod> ProizvodRepo = SqlRepoFactory.GetProizvodRepo(this._cs);

            return this.Ok(ProizvodRepo.Get(id));
        }
    }
}
