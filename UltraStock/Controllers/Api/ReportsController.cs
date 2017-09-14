using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UltraStock.Persistence;

namespace UltraStock.Controllers.Api
{
    public class ReportsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public ReportsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult ReportByYear(int year)
        {
            var values = _context.Invoices
                .Where(i => i.Date.Year == year)
                .ToList()
                .GroupBy(group => group.Date.Month)
                .Select(group => new
                {
                    Month = group.Key,
                    Total = group.Sum(i => i.Total)
                });

            return Ok(values);
        }
    }
}
