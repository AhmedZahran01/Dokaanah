using Dokaanah.Models;
using Dokaanah.Repositories.RepoInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Dokaanah.Repositories.RepoClasses
{
    public class PaymentsRepo:IPaymentRepo
    {

        private readonly Dokkanah2Contex contex10;
        public PaymentsRepo(Dokkanah2Contex c1ontex10)
        {
            contex10 = c1ontex10;
        }
        public IEnumerable<Payment> GetAll()
        {
            return contex10.Payments.Include(p => p.Customer).ToList();
        }



        public Payment GetById(int id)
        {
            return contex10.Payments.Include(p => p.Customer)
                 .FirstOrDefault(m => m.Id == id);
        }


        public int insert(Payment Payment)
        {
            contex10.Add(Payment);
            return contex10.SaveChanges();

        }

        public int update(Payment Payment)
        {
            contex10.Update(Payment);
            return contex10.SaveChanges();
        }
        public int delete(Payment Payment)
        {

            contex10.Payments.Remove(Payment);
            return contex10.SaveChanges();

        }

    }
}
