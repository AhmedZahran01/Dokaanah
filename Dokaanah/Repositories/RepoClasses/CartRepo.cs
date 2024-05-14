using Dokaanah.Models;
using Dokaanah.Repositories.RepoInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Dokaanah.Repositories.RepoClasses
{
    public class CartRepo: ICartRepo
    {
        private readonly Dokkanah2Contex _context;

        public CartRepo(Dokkanah2Contex context)
        {
            _context = context;
        }

        public IEnumerable<Cart> GetAll()
        {
            return _context.Carts.Include(c =>c.Cart_Products).ToList();
        }

        public Cart GetDetails(int id)
        {
            return _context.Carts.Find(id);
        }

        public int Insert(Cart cart)
        {
            _context.Carts.Add(cart);
           
            return _context.SaveChanges();
        }

        public int Update( Cart updatedCart)
        {

            _context.Update(updatedCart);
            return _context.SaveChanges();
        }

        public int Delete(Cart cart)
        {
            
            _context.Carts.Remove(cart);
           return _context.SaveChanges();
        }
    }
}
