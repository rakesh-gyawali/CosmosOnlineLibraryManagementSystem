using System.Web.Mvc;

namespace OnlineLibraryMVCApi.Controllers
{
    public class PublicationController : Controller
    {
        // GET: Publication
        public ActionResult Index()
        {
            return View();
        }
    }
}