using OnlineLibraryMVCApi.Models;
using OnlineLibraryMVCApi.ViewModels;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Data.SqlClient;

namespace OnlineLibraryMVCApi.Controllers
{
    public class BookController : Controller
    {
        private ApplicationDbContext _context;

        public BookController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            return View("BookForm");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Book book)
        {
            book.CategoryId = _context.Categories.Where(n => n.Name == book.Category.Name).SingleOrDefault().Id;
            book.PublicationId = _context.Publications.Where(n => n.Name == book.Publication.Name).SingleOrDefault().Id;
            book.AuthorId = _context.Authors.Where(n => n.Name == book.Author.Name).SingleOrDefault().Id;

            book.DateAdded = DateTime.Now;

            book.Author = null;
            book.Category = null;
            book.Publication = null;

            _context.Books.Add(book);
            _context.SaveChanges();
            return RedirectToAction("Index", "Book");
        }
    }
}