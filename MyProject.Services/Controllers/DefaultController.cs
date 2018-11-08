using MyProject.Common.ViewModels;
using MyProject.Data.Context;
using MyProject.Data.Models;
using MyProject.Logic.Repository;
using MyProject.Logic.UnitOfWork;
using MyProject.ServicesLogic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace MyProject.Services.Controllers
{
    public class DefaultController : ApiController
    {
        UserDetailsService uds = new UserDetailsService();
        public List<UserDetailsVM> GetAll()
        {
            return uds.GetAll();
        }

        [HttpPost]
        public void Post([FromBody]UserDetailsVM value)
        {
            uds.Create(value);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            uds.Delete(new UserDetailsVM()
            {
                UserDetailId = id
            });
        }

        [HttpPut]
        public void Put([FromBody]UserDetailsVM value)
        {
            uds.Update(value);
        }
    }
}
