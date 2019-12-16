using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace Assignment_NET.Controllers
{
    public class ProductController : Controller
    {
        private MyDbContext db = new MyDbContext();
        // GET: Product
        public ActionResult Detail(int id)
        {
            var product = db.Products.Where(c => c.Id == id).FirstOrDefault();
            return View("ProductDetail",product);
        }
    }
}