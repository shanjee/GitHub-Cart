using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Collections.Generic;

namespace ProductCart.Models.Models
{
    [Bind(Exclude = "ProductId")]
    public class Product
    {
        [ScaffoldColumn(false)]
        public int ProductId { get; set; }

        [DisplayName("ProductCategory")]
        public int ProductCategoryId { get; set; }

        [DisplayName("Manufacture")]
        public int ManufactureId { get; set; }

        [Required(ErrorMessage = "An Album Title is required")]
        [StringLength(160)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 100.00,
            ErrorMessage = "Price must be between 0.01 and 100.00")]
        public decimal Price { get; set; }

        //[DisplayName("Album Art URL")]
        //[StringLength(1024)]
        //public string AlbumArtUrl { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
        public virtual Manufacture Manufacture { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}