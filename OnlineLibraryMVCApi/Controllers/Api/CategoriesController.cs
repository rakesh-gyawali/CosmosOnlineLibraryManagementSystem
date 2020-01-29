using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineLibraryMVCApi.Dtos;
using OnlineLibraryMVCApi.Models;
using AutoMapper;

namespace OnlineLibraryMVCApi.Controllers.Api
{
    public class CategoriesController : ApiController
    {
        private ApplicationDbContext _context;

        public CategoriesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/categories
        public IHttpActionResult GetCategories(string query = null)
        {
            var categoriesQuery = _context.Categories.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query))
                categoriesQuery = categoriesQuery.Where(c => c.Name.Contains(query));

            var categoryDto = categoriesQuery.Select(Mapper.Map<Category, CategoryDto>);
            return Ok(categoryDto);
        }

        // GET /api/Categories
        public IHttpActionResult GetCategories(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.Id == id);
            var categoryDto = new CategoryDto
            {
                Name = category.Name
            };
            return Ok(category);
        }
    }
}