using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UltraStock.ViewModels.Invoice
{
    public class InvoiceFormViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Number { get; set; }

        public DateTime Date { get; set; }

        public float SubTotal { get; set; }

        [Range(0, 100)]
        public int DiscountRate { get; set; }

        public float Total { get; set; }

        public int SupplierId { get; set; }

        public List<InvoiceDetailViewModel> InvoiceDetails { get; set; }
    }
}