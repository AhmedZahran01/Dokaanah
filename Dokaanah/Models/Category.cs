namespace Dokaanah.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }

        public virtual ICollection<Product_Category> Product_Categories { get; set; } = new List<Product_Category>();


    }
}
