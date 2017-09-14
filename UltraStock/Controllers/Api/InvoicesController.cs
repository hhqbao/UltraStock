using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using UltraStock.Core.Dtos;
using UltraStock.Core.Models;
using UltraStock.Persistence;
using UltraStock.ViewModels;
using UltraStock.ViewModels.Invoice;

namespace UltraStock.Controllers.Api
{
    public class InvoicesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public InvoicesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetInvoices(int supplierId)
        {
            var invoiceDtos = _context.Invoices
                .Include(i => i.InvoiceDetails.Select(d => d.Product))
                .Where(i => i.SupplierId == supplierId)
                .Take(100)
                .ToList()
                .OrderByDescending(i => i.Date)
                .Select(Mapper.Map<Invoice, InvoiceDto>);

            return Ok(invoiceDtos);
        }

        [HttpPost]
        public IHttpActionResult CreateInvoice(InvoiceFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var newInvoice = new Invoice(viewModel);

            _context.Invoices.Add(newInvoice);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult UpdateInvoice(InvoiceFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var invoiceInDb = _context.Invoices
                .Include(i => i.InvoiceDetails)
                .SingleOrDefault(i => i.Id == viewModel.Id.Value);

            if (invoiceInDb == null)
                return NotFound();

            invoiceInDb.Update(viewModel);
            _context.SaveChanges();

            return Ok();
        }
    }
}
