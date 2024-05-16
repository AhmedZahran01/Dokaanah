namespace Dokaanah.Models
{
    public class ShoppingCartitem
    {
        public int Id { get; set; }

        public Product? product { get; set; }

        public int Quantity { get; set; }
    }
}
