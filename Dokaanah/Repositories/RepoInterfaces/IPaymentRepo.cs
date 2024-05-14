using Dokaanah.Models;

namespace Dokaanah.Repositories.RepoInterfaces
{
    public interface IPaymentRepo
    {
        public IEnumerable<Payment> GetAll();
        public Payment GetById(int id);
        public int insert(Payment payment);
        public int update(Payment payment);
        public int delete(Payment payment);

    }
}
