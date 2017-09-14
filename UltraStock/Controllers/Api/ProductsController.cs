using AutoMapper;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using UltraStock.Core.Dtos;
using UltraStock.Core.Models;
using UltraStock.Persistence;
using UltraStock.ViewModels.Product;

namespace UltraStock.Controllers.Api
{
    public class ProductsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        [HttpGet]
        public IHttpActionResult GetProductsByDescription()
        {
            var productDtos = _context.Products
                .Include(p => p.Category)
                .Include(p => p.BarCodes)
                .ToList()
                .Select(Mapper.Map<Product, ProductDto>);

            return Ok(productDtos);
        }

        [HttpGet]
        public IHttpActionResult GetProductsByDescription(string value)
        {
            var productDtos = _context.Products
                .Include(p => p.BarCodes)
                .Where(p => p.Description.Contains(value))
                .ToList()
                .Select(Mapper.Map<Product, ProductDto>);

            return Ok(productDtos);
        }

        [HttpGet]
        public IHttpActionResult GetProductsByReference(string reference)
        {
            var productDtos = _context.Products
                .Include(p => p.BarCodes)
                .Where(p => p.Reference.Contains(reference))
                .ToList()
                .Select(Mapper.Map<Product, ProductDto>);

            return Ok(productDtos);
        }

        [HttpPost]
        public IHttpActionResult CreateProduct(ProductFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var product = new Product
            {
                Description = viewModel.Description,
                CategoryId = viewModel.CategoryId,
                Reference = viewModel.Reference,
            };

            viewModel.BarCodes.ForEach(b => product.BarCodes.Add(new BarCode { Value = b.Value }));

            _context.Products.Add(product);
            _context.SaveChanges();

            return Ok(Mapper.Map<Product, ProductDto>(product));
        }

        [HttpPut]
        public IHttpActionResult UpdateProduct(ProductFormViewModel viewModel)
        {
            if (!ModelState.IsValid || !viewModel.Id.HasValue)
                return BadRequest();

            var product = _context.Products
                .Include(p => p.BarCodes)
                .SingleOrDefault(p => p.Id == viewModel.Id.Value);

            product.Update(viewModel);

            _context.SaveChanges();

            return Ok(Mapper.Map<Product, ProductDto>(product));
        }
    }
}
