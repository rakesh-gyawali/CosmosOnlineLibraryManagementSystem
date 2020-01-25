using OnlineLibraryMVCApi.Models;
using System.Linq;
using System.Web.Http;

namespace OnlineLibraryMVCApi.Controllers.Api
{
    public class PublicationsController : ApiController
    {
        private ApplicationDbContext _context;

        public PublicationsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/Publications
        public IHttpActionResult GetPublications()
        {
            var pub = _context.Publications.ToList();
            return Ok(pub);
        }

        // GET /api/Publications/id

        public IHttpActionResult GetPublications(int id)
        {
            return Ok();
        }
    }
}