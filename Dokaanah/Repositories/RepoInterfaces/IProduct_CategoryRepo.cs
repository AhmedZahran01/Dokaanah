using Dokaanah.Models;

namespace Dokaanah.Repositories.RepoInterfaces
{
    public interface IProduct_CategoryRepo
    {
        public IEnumerable<Product_Category> GetAll();
        //public Product_Category GetById(int id);
        //public int insert(Product_Category Product_Category);
        //public int update(Product_Category Product_Category);
        //public int delete(Product_Category Product_Category);

    }
}
