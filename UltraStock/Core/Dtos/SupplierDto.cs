namespace UltraStock.Core.Dtos
{
    public class SupplierDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ABN { get; set; }
        public string ACN { get; set; }
        public string Phone { get; set; }
        public string Fax { set; get; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string PostAddress { get; set; }
    }
}