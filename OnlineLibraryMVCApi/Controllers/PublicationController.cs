using System.Web.Mvc;
using System;
using System.Linq;
using System.Data.Entity;
using OnlineLibraryMVCApi.ViewModels;
using OnlineLibraryMVCApi.Models;

namespace OnlineLibraryMVCApi.Controllers
{
    public class PublicationController : Controller
    {
        private ApplicationDbContext _context;

        public PublicationController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Publication
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var viewModel = new PublicationViewModel();
            return View("PublicationForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Publication publication)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new PublicationViewModel(publication);
                return View("BookForm", viewModel);
            }

            if (publication.Id == 0)
                _context.Publications.Add(publication);
            else
            {
                var publicationInDb = _context.Publications.SingleOrDefault(p => p.Id == publication.Id);
                publicationInDb.Name = publication.Name;
                publicationInDb.Address = publication.Address;
            }

            _context.SaveChanges();

            return View("Index");
        }

        public ActionResult Edit(int id)
        {
            var publication = _context.Publications.SingleOrDefault(p => p.Id == id);

            if (publication == null)
                return HttpNotFound();

            var viewModel = new PublicationViewModel(publication);
            return View("PublicationForm", viewModel);
        }
    }
}