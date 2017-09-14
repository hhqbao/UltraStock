namespace UltraStock.Core.Dtos
{
    public class InvoiceDetailDto
    {
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public float Quantity { get; set; }
        public float Price { get; set; }
        public float Gst { get; set; }
        public int? DiscountRate { get; set; }
        public float Total { get; set; }

        public ProductDto Product { get; set; }
    }
}