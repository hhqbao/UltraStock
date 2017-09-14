using AutoMapper;
using System.Linq;
using System.Web.Http;
using UltraStock.Core.Dtos;
using UltraStock.Core.Models;
using UltraStock.Persistence;

namespace UltraStock.Controllers.Api
{
    public class CategoriesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        [HttpGet]
        public IHttpActionResult GetCategories()
        {
            var categoryDtos = _context.Categories
                .ToList()
                .Select(Mapper.Map<Category, CategoryDto>);

            return Ok(categoryDtos);
        }
    }
}
