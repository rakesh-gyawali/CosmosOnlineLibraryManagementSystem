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
            var viewModel = new BookFormViewModel(); // value of int will be initialized.
            return View("BookForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Book book)
        {
            book.CategoryId = _context.Categories.Where(n => n.Name == book.Category.Name).SingleOrDefault().Id;
            book.PublicationId = _context.Publications.Where(n => n.Name == book.Publication.Name).SingleOrDefault().Id;
            book.AuthorId = _context.Authors.Where(n => n.Name == book.Author.Name).SingleOrDefault().Id;

            book.Author = null;
            book.Category = null;
            book.Publication = null;

            if (!ModelState.IsValid)
            {
                var viewModel = new BookFormViewModel(book);
                return View("BookForm", viewModel);
            }

            if (book.Id != 0)
            {
                var bookInDb = _context.Books.Single(b => b.Id == book.Id);

                bookInDb.Isbn = book.Isbn;
                bookInDb.Name = book.Name;
                bookInDb.AuthorId = book.AuthorId;
                bookInDb.PublicationId = book.PublicationId;
                bookInDb.CategoryId = book.CategoryId;
                bookInDb.TotalPage = book.TotalPage;
            }
            else
            {
                book.DateAdded = DateTime.Now;
                _context.Books.Add(book);
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Book");
        }

        public ActionResult Edit(int id)
        {
            var book = _context.Books.Include(b => b.Author).Include(b => b.Publication).Include(b => b.Category).SingleOrDefault(b => b.Id == id);
            if (book == null)
                return HttpNotFound();

            var viewModel = new BookFormViewModel(book);
            return View("BookForm", viewModel);
        }
    }
}