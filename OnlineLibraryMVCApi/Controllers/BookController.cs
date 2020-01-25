using System.Web.Mvc;

namespace OnlineLibraryMVCApi.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }
    }
}