using Dokaanah.Models;

namespace Dokaanah.Repositories.RepoInterfaces
{
    public interface ICategoriesRepo
    {
        List<Product> GetAllProductsForAllCategories();

        List<Product> GetProductsForCategory(int categoryId);

        //List<Product> GetAllProductsFromAllCategories();
        public IEnumerable<Category> GetAll();
        //public Category GetById(int id);
        //public Category GetprodByCatId(int id);
        //public int insert(Category category);
        //public int update(Category category);
        //public int delete(Category category);
    }
}
