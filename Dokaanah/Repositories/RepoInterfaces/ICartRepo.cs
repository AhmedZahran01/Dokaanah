using Dokaanah.Models;

namespace Dokaanah.Repositories.RepoInterfaces
{
    public interface ICartRepo
    {
        public IEnumerable<Cart> GetAll();
        public Cart GetDetails(int id);
        public int Insert(Cart cart);
        public int Update(Cart cart);
        public int Delete(Cart cart);
    }
}
