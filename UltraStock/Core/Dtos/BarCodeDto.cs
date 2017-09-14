namespace UltraStock.Core.Dtos
{
    public class BarCodeDto
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
    }
}