using Dokaanah.Models;
using Dokaanah.Repositories.RepoInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Dokaanah.Repositories.RepoClasses
{
    public class CategoriesRepo: ICategoriesRepo
    {
        private readonly Dokkanah2Contex _context;
        public CategoriesRepo(Dokkanah2Contex c1ontex10)
        {
            _context = c1ontex10;
        }
        // Get Products From all Categories
        public List<Product> GetAllProductsForAllCategories()
        {
            return _context.Categories
                           .SelectMany(c => c.Product_Categories)
                           .Select(p => p.P)
                           .ToList();
        }

        // Get Products From Special Category
        public List<Product> GetProductsForCategory(int categoryId)
        {
            return _context.Categories
                           .Where(c => c.Id == categoryId)
                           .SelectMany(c => c.Product_Categories)
                           .Select(p => p.P)
                           .ToList();
        }




        //public List<Product> GetAllProductsFromAllCategories()
        //{
        //    return contex10.Categories
        //                   .SelectMany(c => c.Product_Categories)
        //                   .Select(a => a.P)
        //                   .ToList();
        //}

        public Category GetById(int id)
        {
            return _context.Categories.FirstOrDefault(m => m.Id == id);
        }

        IEnumerable<Category> ICategoriesRepo.GetAll()
        {
            return _context.Categories.ToList();
        }

        //public Category GetprodByCatId(int id)
        //{
        //    return contex10.Categories.Include(c => c.Product_Categories).FirstOrDefault(m => m.Id == id);
        //}

        //public int insert(Category category)
        //{
        //    contex10.Categories.Add(category);
        //    return contex10.SaveChanges();

        //}

        //public int update(Category category)
        //{
        //    contex10.Update(category);
        //    return contex10.SaveChanges();
        //}

        //public int delete(Category category)
        //{

        //    contex10.Categories.Remove(category);
        //    return contex10.SaveChanges();

        //}


        //public IEnumerable<Category> GetAll()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
