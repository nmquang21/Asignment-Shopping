using Assignment_NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace Assignment_NET.Controllers
{
    public class AdminController : Controller
    {
        private MyDbContext db = new MyDbContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
      
    }
}