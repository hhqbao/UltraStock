using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UltraStock.Core.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { set; get; }

        public Category()
        {
            Products = new Collection<Product>();
        }
    }
}