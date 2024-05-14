using Dokaanah.Models;

namespace Dokaanah.Repositories.RepoInterfaces
{
    public interface IProductsRepo
    {


        IEnumerable<Product> ListProducts();

        Product GetProductById(int productId);

        List<Product> GetRandomProducts(int count);

        void AddProductToCart(int productId, int cartId);


        List<Product> GetProductsWithItsCategories();





        //public IEnumerable<Product> GetAll();

        //public IEnumerable<Product> GetPrdCat();
        //public IQueryable<Product> SearchByName(string Name);
        //public IQueryable<Product> SearchByPrice(float startRange, float endRange);
        //public IEnumerable<Product> GetTopRate();
        //public List<string> GetAllImgURL();
        //public Product GetById(int id); 
        //public int insert(Product product);
        //public int update(Product product);
        //public int delete(Product product);

    }
}
