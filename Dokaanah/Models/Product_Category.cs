namespace Dokaanah.Models
{
    public class Product_Category
    {
        public int Pid { get; set; }
        public int Cid { get; set; }

        public virtual Product P { get; set; } = null!;
        public virtual Category C { get; set; } = null!;
    }
}
