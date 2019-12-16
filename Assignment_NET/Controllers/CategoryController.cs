using Assignment_NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace Assignment_NET.Controllers
{
    public class CategoryController : Controller
    {
        private MyDbContext db = new MyDbContext();
        // GET: Category
        public ActionResult Index(int? page, int? limit, int? cid)
        {
            var products = new List<Product>();
            ViewBag.Categories = db.Categories.ToList();

            if (page == null)
            {
                page = 1;
            }

            if (limit == null)
            {
                limit = 6;
            }
            if(cid == null)
            {
                products = db.Products.OrderBy(c=>c.CreatedAt).ToList();
            }
            else
            {
                products = db.Products.OrderBy(c => c.CreatedAt).Where(c => c.Categoty.Id == cid).ToList();
                ViewBag.categoryName = db.Categories.Where(c => c.Id == cid).FirstOrDefault().Name;
            }
            ViewBag.limit = limit;
            ViewBag.TotalPage = Math.Ceiling((double)products.Count() / limit.Value);
            ViewBag.CurrentPage = page;
            ViewBag.Limit = limit;
            ViewBag.Cid = cid;

            var list = products.Skip((page.Value - 1) * limit.Value).Take(limit.Value).ToList();
            return View("category", list);
        }
    }
}