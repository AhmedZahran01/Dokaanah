using Dokaanah.Models;
using Dokaanah.Repositories.RepoInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Dokaanah.Repositories.RepoClasses
{
    public class Product_CategoryRepo : IProduct_CategoryRepo
    {
        private readonly Dokkanah2Contex contex10;
        public Product_CategoryRepo(Dokkanah2Contex c1ontex10)
        {
            contex10 = c1ontex10;
        }
        public IEnumerable<Product_Category> GetAll()
        {
            return contex10.Product_Categories.Include(p => p.C).Include(p => p.P).ToList();
        }

      

       
    }
}
