using Dokaanah.Models;
using Dokaanah.Repositories.RepoInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Dokaanah.Repositories.RepoClasses
{
    public class ProductsRepo:IProductsRepo
    {
        #region constroctor
        private readonly Dokkanah2Contex _context;

        public ProductsRepo(Dokkanah2Contex context)
        {
            _context = context;
        } 
        #endregion


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

      

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.Include(p => p.Order).Include(p => p.Seller).ToList();
        }


        public int insert(Product Product)
        {
            _context.Add(Product);
            return _context.SaveChanges();

        }



        public int update(Product Product)
        {
            _context.Update(Product);
            return _context.SaveChanges();
        }

        public int delete(Product Product)
        {

            _context.Products.Remove(Product);
            return _context.SaveChanges();

        }



        public IQueryable<Product> SearchByName(string name)
        {
            return _context.Products.Where(p => p.Name.ToLower().Contains(name));

        }

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

        //private readonly Dokkanah2Contex contex10;
        //public ProductsRepo(Dokkanah2Contex c1ontex10)
        //{
        //    contex10 = c1ontex10;
        //}








    }
}
