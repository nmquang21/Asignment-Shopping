using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace Assignment_NET.Controllers
{
    public class HomeController : Controller
    {
        private MyDbContext db = new MyDbContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Category() {
            ViewBag.Categories = db.Categories.ToList();
            var products = db.Products.ToList();
            return View(products);
        }
        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult BlogDetail()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Cart()
        {
            return View();
        }
        public ActionResult Confirmation(int? id)
        {
            var order = db.Orders.Find(id);
            return View(order);
        }
    }
}