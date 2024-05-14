using Dokaanah.Models;
using Dokaanah.Repositories.RepoInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Dokaanah.Repositories.RepoClasses
{
    public class CustomersRepo:ICustomersRepo
    {
        private readonly Dokkanah2Contex contex10;
        public CustomersRepo(Dokkanah2Contex c1ontex10)
        {
            contex10 = c1ontex10;
        }
        public IEnumerable<Customer> GetAll()
        {
            return contex10.Customer1s.ToList();
        }

        public Customer GetById(string id)
        {
            return contex10.Customer1s.FirstOrDefault(m => m.Id == id);
        }

        public int insert(Customer customer)
        {
            contex10.Add(customer);
            return contex10.SaveChanges();

        }

        public int update(Customer customer)
        {
            contex10.Update(customer);
            return contex10.SaveChanges();
        }

        public int delete(Customer customer)
        {

            contex10.Customer1s.Remove(customer);
            return contex10.SaveChanges();

        }
    }
}
