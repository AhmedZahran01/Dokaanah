using Dokaanah.Models;
using Dokaanah.Repositories.RepoInterfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Dokaanah.Repositories.RepoClasses
{
    public class OrdersRepo:IOrdersRepo
    {

        private readonly Dokkanah2Contex contex10;
        public OrdersRepo(Dokkanah2Contex c1ontex10)
        {
            contex10 = c1ontex10;
        }
        public IEnumerable<Order> GetAll()
        
        {
            return (from a in contex10.Orders.Include(b => b.Customer)

                    select a)
                                   .ToList();


            //contex10.Orders.Include(o => o.Customer).ToList();

            //contex10.Orders
            //   .FirstOrDefault(m => m.Id == id);

           

        
        }


        public Order GetById(int id)
        {
            return  (from a in contex10.Orders.Include(o => o.Customer)
                     where a.Id == id
             select a).FirstOrDefault();

            //contex10.Orders
            //   .FirstOrDefault(m => m.Id == id);

        }


        public int insert(Order order)
        {
            contex10.Add(order);
            return contex10.SaveChanges();

        }

        public int update(Order order)
        {
            contex10.Update(order);
            return contex10.SaveChanges();
        }
        public int delete(Order order)
        {

            contex10.Orders.Remove(order);
            return contex10.SaveChanges();

        }
    }
}
