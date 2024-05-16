using Dokaanah.Models;

namespace Dokaanah.Repositories.RepoInterfaces
{
    public interface ICartProductRepo
    {
        Cart_Product GetCartItem(int productId, int cartId);
        void AddCartItem(Cart_Product cartProduct);
        void UpdateCartItem(Cart_Product cartProduct);
        void RemoveCartItem(Cart_Product cartProduct);
    }
}