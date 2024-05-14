using Dokaanah.Models;

namespace Dokaanah.Repositories.RepoInterfaces
{
    public interface Iproduct_customerRepo
    {
        public IEnumerable<product_customer> GetAll();
        public IEnumerable<Product> GetTopProducts();
        //public int insert(Product_Category Product_Category);
        //public int update(Product_Category Product_Category);
        //public int delete(Product_Category Product_Category);

    }
}
