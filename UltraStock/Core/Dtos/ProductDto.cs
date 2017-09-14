using System.Collections.Generic;

namespace UltraStock.Core.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
        public ICollection<BarCodeDto> BarCodes { get; set; }
    }
}