using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using TestJson.Models;
using Newtonsoft.Json;

namespace TestJson.Controllers
{
    public class HomeController : Controller
    {
        public string url { get; set; }

        public HomeController()
        {
            //url = "http://localhost:30214/api/todo";
            url = "http://10.104.10.44/PatientJsonApi/api/Patient/1213048085/jsonp?callback=?";
        }

        // GET: Home
        public ActionResult Index()
        {
            var client = new WebClient { Encoding = System.Text.Encoding.UTF8 };
            var json = client.DownloadString(url);

            //List<Todo> result = JsonConvert.DeserializeObject<List<Todo>>(json);
            List<Patient> result = JsonConvert.DeserializeObject<List<Patient>>(json);
            
            return View(result);
        }

    }
}