using System.ComponentModel.DataAnnotations;

namespace UltraStock.ViewModels.BarCode
{
    public class BarCodeViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Value { get; set; }

        public int? Temp { get; set; }
    }
}