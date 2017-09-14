using UltraStock.Controllers.Api;
using UltraStock.ViewModels;
using UltraStock.ViewModels.Invoice;

namespace UltraStock.Core.Models
{
    public class InvoiceDetail
    {
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public float Quantity { get; set; }
        public float Price { get; set; }
        public float Gst { get; set; }
        public int? DiscountRate { get; set; }
        public float Total { get; set; }

        public Invoice Invoice { get; set; }
        public Product Product { get; set; }

        public InvoiceDetail()
        {

        }

        public InvoiceDetail(InvoiceDetailViewModel detail) : this()
        {
            Update(detail);
        }

        public void Update(InvoiceDetailViewModel detail)
        {
            ProductId = detail.ProductId;
            Quantity = detail.Quantity;
            Price = detail.Price;
            Gst = detail.Gst;
            DiscountRate = detail.DiscountRate;
            Total = detail.Total;
        }
    }
}