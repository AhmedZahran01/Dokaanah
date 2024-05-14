using Dokaanah.Models;
using Dokaanah.Repositories.RepoInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Dokaanah.Repositories.RepoClasses
{
    public class ProductsRepo:IProductsRepo
    {
        private readonly Dokkanah2Contex _context;

        public ProductsRepo(Dokkanah2Contex context)
        {
            _context = context;
        }

        public IEnumerable<Product> ListProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int productId)
        {
            return _context.Products
                .Include(p => p.Product_Categories)
                    .ThenInclude(pc => pc.C) // Include the Category entity
                .FirstOrDefault(p => p.Id == productId);
        }

        public List<Product> GetRandomProducts(int count)
        {
            return _context.Products.OrderBy(p => Guid.NewGuid()).Take(count).ToList();
        }

        public void AddProductToCart(int productId, int cartId)
        {
            var cartProduct = new Cart_Product
            {
              Prid = productId,
              Caid  = cartId
            };

            _context.Cart_Products.Add(cartProduct);
            _context.SaveChanges();
        }

        public List<Product> GetProductsWithItsCategories()
        {
            return _context.Products.Include(x=>x.Product_Categories).ToList();
        }

        //private readonly Dokkanah2Contex contex10;
        //public ProductsRepo(Dokkanah2Contex c1ontex10)
        //{
        //    contex10 = c1ontex10;
        //}

        //public IEnumerable<Product> GetAll()
        //{
        //    return contex10.Products.Include(p => p.Order).Include(p => p.Seller).ToList();
        //}

        //// For ProductViewModel
        //public IEnumerable<Product> GetGetPrdCat()
        //{
        //    return contex10.Products.Include(a => a.Product_Categories).ToList();
        //}
        //public IEnumerable<Product> GetTopRate()
        //{
        //    return contex10.Products.Include(p => p.Order).Include(p => p.Seller).ToList();
        //}
        //public List<string> GetAllImgURL()
        //{
        //    return contex10.Products.Select(p => p.ImgUrl).ToList();
        //}

        //public Product GetById(int id)
        //{
        //   return contex10.Products
        //                    .Include(p => p.Order)
        //                    .Include(p => p.Seller)
        //                    .FirstOrDefault(m => m.Id == id);
        //}



        //public int insert(Product Product)
        //{
        //    contex10.Add(Product);
        //    return contex10.SaveChanges();

        //}

        //public int update(Product Product)
        //{
        //    contex10.Update(Product);
        //    return contex10.SaveChanges();
        //}
        //public int delete(Product Product)
        //{

        //    contex10.Products.Remove(Product);
        //    return contex10.SaveChanges();

        //}

        //public IQueryable<Product> SearchByName(string name)
        //{
        //    return contex10.Products.Where(p => p.Name.ToLower().Contains(name));

        //}

        //public IQueryable<Product> SearchByPrice( float startRange, float endRange)
        //{
        //    return contex10.Products.Where(e => e.Price > startRange && e.Price <= endRange);
        //}

        //public Product GetPrdCat()
        //{
        //    throw new NotImplementedException();
        //}

        //IEnumerable<Product> IProductsRepo.GetPrdCat()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
