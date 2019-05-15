using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Elephants.Models;
using Microsoft.AspNetCore.Http;


namespace Elephants.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            int? Count = HttpContext.Session.GetInt32("Count");
            if(Count != null){
                Count++;
                ViewBag.Count = Count;
                HttpContext.Session.SetInt32("Count", (int)Count);
            }
            else
            {
                HttpContext.Session.SetInt32("Count", 1);
                ViewBag.Count = 1;
            }
            return View();
        }

        [Route("reset")]
        [HttpGet]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }

        [Route("set/{n}")]
        [HttpGet]
        public IActionResult SetCount(int n)
        {
            HttpContext.Session.SetInt32("Count", n-1);
            return Redirect("/");
        }

    }
}
