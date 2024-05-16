using Dokaanah.Models;
using Dokaanah.Repositories.RepoInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Dokaanah.Repositories.RepoClasses
{

    public class CartProductRepository : ICartProductRepo
    {
        private readonly Dokkanah2Contex _context;

        public CartProductRepository(Dokkanah2Contex context)
        {
            _context = context;
        }

        public Cart_Product GetCartItem(int productId, int cartId)
        {
            return _context.Cart_Products
                .FirstOrDefault(cp => cp.Prid == productId && cp.Caid == cartId);
        }

        public void AddCartItem(Cart_Product cartProduct)
        {
            _context.Cart_Products.Add(cartProduct);
            _context.SaveChanges();
        }

        public void UpdateCartItem(Cart_Product cartProduct)
        {
            _context.Entry(cartProduct).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveCartItem(Cart_Product cartProduct)
        {
            _context.Cart_Products.Remove(cartProduct);
            _context.SaveChanges();
        }
    }
}

