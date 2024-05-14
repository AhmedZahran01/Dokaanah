namespace Dokaanah.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Product> GetProducts { get; set; } = new List<Product>();

    }
}
