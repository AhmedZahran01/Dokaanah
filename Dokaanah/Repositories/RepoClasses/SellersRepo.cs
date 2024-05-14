using Dokaanah.Models;
using Dokaanah.Repositories.RepoInterfaces;

namespace Dokaanah.Repositories.RepoClasses
{
    public class SellersRepo:ISellersRepo
    {
        private readonly Dokkanah2Contex contex10;
        public SellersRepo(Dokkanah2Contex c1ontex10)
        {
            contex10 = c1ontex10;
        }
        public IEnumerable<Seller> GetAll()
        {
            return contex10.Sellers.ToList();
        }


        public Seller GetById(int id)
        {
            return contex10.Sellers
                 .FirstOrDefault(m => m.Id == id);
        }


        public int insert(Seller seller)
        {
            contex10.Add(seller);
            return contex10.SaveChanges();

        }

        public int update(Seller seller)
        {
            contex10.Update(seller);
            return contex10.SaveChanges();
        }
        public int delete(Seller seller)
        {

            contex10.Sellers.Remove(seller);
            return contex10.SaveChanges();

        }

    }
}
