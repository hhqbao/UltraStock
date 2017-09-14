using System.ComponentModel.DataAnnotations;

namespace UltraStock.ViewModels.Supplier
{
    public class SupplierFormViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        public string ABN { get; set; }
        public string ACN { get; set; }
        public string Fax { set; get; }
        public string Mobile { get; set; }
        public string PostAddress { get; set; }
    }
}
