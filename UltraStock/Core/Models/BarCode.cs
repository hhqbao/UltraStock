namespace UltraStock.Core.Models
{
    public class BarCode
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public void UpdateValue(string value)
        {
            Value = value;
        }
    }
}