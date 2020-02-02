using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineLibraryMVCApi.ViewModels;
using System.Web.Mvc;
using OnlineLibraryMVCApi.Models;

namespace OnlineLibraryMVCApi.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author

        private ApplicationDbContext _context;

        public AuthorController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var viewModel = new AuthorFormViewModel();
            return View("AuthorForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Author author)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new AuthorFormViewModel(author);
                return View("AuthorForm", viewModel);
            }
            if (author.Id == 0)
            {
                _context.Authors.Add(author);
            }
            else
            {
                var authorInDb = _context.Authors.SingleOrDefault(a => a.Id == author.Id);
                authorInDb.Name = author.Name;
            }
            _context.SaveChanges();
            return View("Index");
        }

        public ActionResult Edit(int id)
        {
            var author = _context.Authors.SingleOrDefault(a => a.Id == id);

            if (author == null)
            {
                return HttpNotFound();
            }

            var viewModel = new AuthorFormViewModel(author);

            return View("AuthorForm", viewModel);
        }
    }
}