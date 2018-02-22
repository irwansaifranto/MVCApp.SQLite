using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvcApp.SQLite.Models;

namespace mvcApp.SQLite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new BloggingContext()) 
            {
                db.Blogs.Add(new Blog {
                    Url = "http://blogs.msdn.com/adonet"
                });
                var count = db.SaveChanges();
                
                ViewData["Blogs"] = db.Blogs.FirstOrDefault().Url;

                return View();
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
