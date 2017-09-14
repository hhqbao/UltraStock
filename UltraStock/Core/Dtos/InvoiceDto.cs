using System;
using System.Collections.Generic;

namespace UltraStock.Core.Dtos
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public float SubTotal { get; set; }
        public int? DiscountRate { get; set; }
        public float Total { get; set; }

        public int SupplierId { get; set; }

        public ICollection<InvoiceDetailDto> InvoiceDetails { get; set; }
    }
}