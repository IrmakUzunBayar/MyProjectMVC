using MyProject.Common.Logs;
using MyProject.Common.ViewModels;
using MyProject.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Mvc.Controllers
{
    public class HomeController : Controller
    {
        HttpClient client = new HttpClient();


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserDetailsVM vm)
        {
            vm.ApplicationUserId = "d36eb321-38ea-4d45-8f34-dccd7a2eeb3b";
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var content = new StringContent(JsonConvert.SerializeObject(vm), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("http://localhost:63061/api/Default", content).GetAwaiter().GetResult();

            return View();
        }

        public JsonResult GetAllUserDetails(string text)
        {
            client.DefaultRequestHeaders.Clear();
            HttpResponseMessage response = client.GetAsync("http://localhost:63061/api/Default/GetAll").GetAwaiter().GetResult();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var dataResult = JsonConvert.DeserializeObject<List<UserDetailsVM>>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());          

            return Json(dataResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteUser(int DeletedId)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.DeleteAsync("http://localhost:63061/api/Default/" + DeletedId).GetAwaiter().GetResult();
            return View();
        }

        public ActionResult DeleteUser()
        {
            return View();
        }

        public ActionResult UpdateUser()
        {           
            return View();
        }

        [HttpPost]
        public ActionResult UpdateUser(UserDetailsVM vm, int UpdatedId)
        {
            vm.UserDetailId = UpdatedId;
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var content = new StringContent(JsonConvert.SerializeObject(vm), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync("http://localhost:63061/api/Default", content).GetAwaiter().GetResult();
            return View();
        }
    }
}