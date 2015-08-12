using ProductCart.Models.Models;
using System.Collections.Generic;


namespace ProductCart.Models.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}