using Dokaanah.Models;

namespace Dokaanah.Repositories.RepoInterfaces
{
    public interface IOrdersRepo
    {
        public IEnumerable<Order> GetAll();
        public Order GetById(int id);
        public int insert(Order order);
        public int update(Order order);
        public int delete(Order order);
    }
}
