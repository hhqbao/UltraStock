using AutoMapper;
using System.Linq;
using System.Web.Http;
using UltraStock.Core.Dtos;
using UltraStock.Core.Models;
using UltraStock.Persistence;
using UltraStock.ViewModels.Supplier;

namespace UltraStock.Controllers.Api
{
    public class SuppliersController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public SuppliersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        [HttpGet]
        public IHttpActionResult GetSuppliers()
        {
            var supplierDtos = _context.Suppliers
                .ToList()
                .Select(Mapper.Map<Supplier, SupplierDto>);

            return Ok(supplierDtos);
        }

        [HttpPost]
        public IHttpActionResult Create(SupplierFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var supplier = new Supplier();
            supplier.Update(viewModel);

            _context.Suppliers.Add(supplier);
            _context.SaveChanges();

            return Ok(Mapper.Map<Supplier, SupplierDto>(supplier));
        }

        [HttpPut]
        public IHttpActionResult Update(SupplierFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var supplier = _context.Suppliers.SingleOrDefault(s => s.Id == viewModel.Id.Value);

            if (supplier == null)
                return NotFound();

            supplier.Update(viewModel);
            _context.SaveChanges();

            return Ok(Mapper.Map<Supplier, SupplierDto>(supplier));
        }
    }
}
