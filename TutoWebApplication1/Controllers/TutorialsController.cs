using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TutoWebApplication1.Models;

namespace TutoWebApplication1.Controllers
{
    public class TutorialsController : Controller
    {
        string resultString;

        // GET: TutorialsController
        public ActionResult Index()
        {
            // Get data from our API
            string URL = "http://localhost:60427/Tuto/";
            using (var client = new HttpClient())
            {
                var responseTask = client.GetAsync(URL);
                responseTask.Wait();

                HttpResponseMessage result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    resultString = result.Content.ReadAsStringAsync().Result;
                }
            }

            var tutoList = JsonConvert.DeserializeObject<Tutos[]>(resultString);

            //return new ContentResult { Content = "Das ist die Liste von Tutos" };
            return View(tutoList);
        }

        // GET: TutorialsController/Details/5
        public ActionResult Details(int id)
        {
            /*if (id == 0)
            {
                return RedirectToAction("Index", "Home"); // Redirect the user
                //return new ContentResult { Content = "Dieses Tuto existier leider nicht !!"};
            }
            else
            {
                return new ContentResult { Content = "Das ist Seite des Totos " + id };
            }*/
            
            return View();
        }

        // GET: TutorialsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TutorialsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [Route("tuto/{year:int}/{month:int}")]
        public ActionResult Test(int year, int month)
        {

             return new ContentResult { Content = "Das Tuto wurde am " + month + "/" + year + " veröffentlicht"};
           
            //return View();
        }
    }
}
