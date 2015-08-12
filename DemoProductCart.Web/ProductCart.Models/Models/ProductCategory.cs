using System.Collections.Generic;

namespace ProductCart.Models.Models
{
    public partial class ProductCategory
    {
        public int ProductCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}
