using OnlineLibraryMVCApi.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using OnlineLibraryMVCApi.Dtos;
using System;

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
        public IHttpActionResult GetPublication(string query = null)
        {
            var pubQuery = _context.Publications.AsQueryable();
            if (!string.IsNullOrWhiteSpace(query))
                pubQuery = pubQuery.Where(p => p.Name.Contains(query));

            var pubDto = pubQuery.Select(Mapper.Map<Publication, PublicationDto>);
            return Ok(pubDto);
        }

        // GET /api/Publications/id

        public IHttpActionResult GetPublication(int id)
        {
            var pub = _context.Publications.SingleOrDefault(p => p.Id == id);

            var pubDto = new PublicationDto
            {
                Name = pub.Name
            };
            return Ok(pub);
        }

        // POST /api/publications
        [HttpPost]
        public IHttpActionResult CreatePublication(PublicationDto pubDto)
        {
            var pub = new Publication
            {
                Name = pubDto.Name
            };

            pubDto.Id = pub.Id;

            _context.Publications.Add(pub);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + pubDto.Id), pubDto);
        }

        // PUT /api/publications/Id
        [HttpPut]
        public void UpdatePublication(int id, PublicationDto pubDto)
        {
            var pub = _context.Publications.SingleOrDefault(p => p.Id == id);

            pub.Name = pubDto.Name;

            _context.SaveChanges();
        }

        // DELETE /api/publications/Id
        [HttpDelete]
        public void DeletePublication(int id)
        {
            var pub = _context.Publications.SingleOrDefault(p => p.Id == id);

            _context.Publications.Remove(pub);
            _context.SaveChanges();
        }
    }
}