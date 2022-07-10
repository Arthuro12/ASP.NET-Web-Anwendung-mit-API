using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoWebApplication1.Models;

namespace TutoWebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // ContentResult return a value
            //return new ContentResult {  Content = "Das ist die Home-Seite" };

            // Send data from the Controller to the view via ViewBag
            ViewBag.title = "C# Tuto";
            ViewBag.price = 49;
            ViewBag.img = "wpf.png";
            ViewBag.description = "Beschreibung des Tutos über C#";

            // Send data from the Controller to the view via object
            var tuto = new Tutos
            {
                Title = "Werden Sie einen Pro von Java",
                Price = 40,
                Description = "Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet."
            };

            return View(tuto);
        }
    }
}
