using OnlineLibraryMVCApi.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using OnlineLibraryMVCApi.Dtos;
using System;

namespace OnlineLibraryMVCApi.Controllers.Api
{
    public class BooksController : ApiController
    {
        private ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        //Every action must return either IEnumerable or IQuryable.

        // GET /api/Books
        public IHttpActionResult GetBook()
        {
            var book = _context.Books
               .Include(b => b.Author).Include(b => b.Publication)
               .Include(b => b.Category).ToList()
               .Select(Mapper.Map<Book, BookDto>);

            return Ok(book);
        }

        // GET /api/Books/id
        public IHttpActionResult GetBook(int id)
        {
            var book = _context.Books
                .Include(b => b.Author).Include(b => b.Publication)
                .Include(b => b.Category).SingleOrDefault(b => b.Id == id);

            var bookDto = new BookDto
            {
                Id = book.Id,
                Isbn = book.Isbn,
                Name = book.Name,
                AuthorId = book.AuthorId,
                PublicationId = book.PublicationId,
                CategoryId = book.CategoryId,
                TotalPage = book.TotalPage,
                Publication = book.Publication,
                Author = book.Author,
                Category = book.Category,
            };

            return Ok(bookDto);
        }

        // POST /api/books/Id
        [HttpPost]
        public IHttpActionResult CreateBook(BookDto bookDto)
        {
            try
            {
                var book = new Book
                {
                    Isbn = bookDto.Isbn,
                    Name = bookDto.Name,
                    AuthorId = bookDto.AuthorId,
                    PublicationId = bookDto.PublicationId,
                    CategoryId = bookDto.CategoryId,
                    TotalPage = bookDto.TotalPage,
                    Publication = bookDto.Publication,
                    Author = bookDto.Author,
                    Category = bookDto.Category
                };

                bookDto.Id = book.Id;
                _context.Books.Add(book);
                _context.SaveChanges();

                return Created(new Uri(Request.RequestUri + "/" + bookDto.Id), bookDto);
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }

        // PUT /api/books/Id
        [HttpPut]
        public void UpdateBook(int id, BookDto bookDto)
        {
            var book = _context.Books
                .Include(b => b.Author).Include(b => b.Publication)
                .Include(b => b.Category).SingleOrDefault(b => b.Id == id);

            book.Isbn = bookDto.Isbn;
            book.Name = bookDto.Name;
            book.AuthorId = bookDto.AuthorId;
            book.PublicationId = bookDto.PublicationId;
            book.CategoryId = bookDto.CategoryId;
            book.TotalPage = bookDto.TotalPage;

            _context.SaveChanges();
        }

        // DELETE /api/books/Id
        [HttpDelete]
        public void DeleteBook(int id)
        {
            var book = _context.Books
                .Include(b => b.Author).Include(b => b.Publication)
                .Include(b => b.Category).SingleOrDefault(b => b.Id == id);

            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}