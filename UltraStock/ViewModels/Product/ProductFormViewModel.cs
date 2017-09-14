using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UltraStock.Controllers.Api;
using UltraStock.ViewModels.BarCode;

namespace UltraStock.ViewModels.Product
{
    public class ProductFormViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public string Reference { get; set; }

        public List<BarCodeViewModel> BarCodes { get; set; }
    }
}