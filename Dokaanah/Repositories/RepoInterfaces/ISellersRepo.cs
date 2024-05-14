using Dokaanah.Models;

namespace Dokaanah.Repositories.RepoInterfaces
{
    public interface ISellersRepo
    {
        public IEnumerable<Seller> GetAll();
        public Seller GetById(int id);
        public int insert(Seller seller);
        public int update(Seller seller);
        public int delete(Seller seller);
    }
}
