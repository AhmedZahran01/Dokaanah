using Dokaanah.Models;

namespace Dokaanah.Repositories.RepoInterfaces
{
    public interface ICustomersRepo
    {
        public IEnumerable<Customer> GetAll();
        public Customer GetById(string id);
        public int insert(Customer customer);
        public int update(Customer customer);
        public int delete(Customer customer);
    }
}
