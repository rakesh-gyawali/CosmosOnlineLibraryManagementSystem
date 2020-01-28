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
        public IHttpActionResult GetAuthor()
        {
            var author = _context.Authors.Select(Mapper.Map<Author, AuthorDto>);
            return Ok(author);
        }

        // GET /api/authors/Id
        public IHttpActionResult GetAuthor(int id)
        {
            var author = _context.Authors.SingleOrDefault(a => a.Id == id);
            var authorDto = new AuthorDto
            {
                FirstName = author.FirstName,
                LastName = author.LastName
            };

            return Ok(authorDto);
        }

        // POST /api/authors/
        public IHttpActionResult CreateAuthor(AuthorDto authorDto)
        {
            var author = new Author
            {
                FirstName = authorDto.FirstName,
                LastName = authorDto.LastName
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

            author.FirstName = authorDto.FirstName;
            author.LastName = authorDto.LastName;

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