using OnlineLibraryMVCApi.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using OnlineLibraryMVCApi.Dtos;
using System;

namespace OnlineLibraryMVCApi.Controllers.Api
{
    public class AuthorsController : ApiController
    {
        private ApplicationDbContext _context;

        public AuthorsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/authors
        public IHttpActionResult GetAuthor(string query = null)
        {
            var authorsQuery = _context.Authors.AsQueryable();
            if (!string.IsNullOrWhiteSpace(query))
            {
                authorsQuery = authorsQuery.Where(m => m.Name.Contains(query));
            }

            var authorDto = authorsQuery.Select(Mapper.Map<Author, AuthorDto>);
            return Ok(authorDto);
        }

        // GET /api/authors/Id
        public IHttpActionResult GetAuthor(int id)
        {
            var author = _context.Authors.SingleOrDefault(a => a.Id == id);
            var authorDto = new AuthorDto
            {
                Name = author.Name
            };

            return Ok(authorDto);
        }

        // POST /api/authors/
        public IHttpActionResult CreateAuthor(AuthorDto authorDto)
        {
            var author = new Author
            {
                Name = authorDto.Name
            };

            authorDto.Id = author.Id;
            _context.Authors.Add(author);

            return Created(new Uri(Request.RequestUri + "/" + authorDto.Id), authorDto);
        }

        // PUT /api/authors/id
        [HttpPut]
        public void UpdateAuthor(int id, AuthorDto authorDto)
        {
            var author = _context.Authors.SingleOrDefault(a => a.Id == id);

            author.Name = authorDto.Name;

            _context.SaveChanges();
        }

        // DELETE /api/authors/id
        public void DeleteAuthor(int id)
        {
            var author = _context.Authors.SingleOrDefault(a => a.Id == id);

            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}