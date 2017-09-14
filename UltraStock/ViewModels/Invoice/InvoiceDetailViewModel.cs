using UltraStock.Core.Models;

namespace UltraStock.ViewModels.Invoice
{
    public class InvoiceDetailViewModel
    {
        public Actions? Action { get; set; }
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public float Quantity { get; set; }
        public float Price { get; set; }
        public float Gst { get; set; }
        public int DiscountRate { get; set; }
        public float Total { get; set; }
    }
}