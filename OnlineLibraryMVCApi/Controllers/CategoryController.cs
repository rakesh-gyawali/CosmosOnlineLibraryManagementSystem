using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineLibraryMVCApi.Models;
using System.Data.Entity;

namespace OnlineLibraryMVCApi.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _context;

        public CategoryController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
    }
}