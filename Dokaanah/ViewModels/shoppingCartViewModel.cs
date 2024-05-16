using Dokaanah.Models;

namespace Dokaanah.ViewModels
{
    public class shoppingCartViewModel
    {
        public List<Product>? CartItems { get; set; }

        public float? TotalPrice { get; set; }

        public int? TotalQuantity { get; set; }
    }
}
