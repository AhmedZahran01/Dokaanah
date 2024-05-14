using System.ComponentModel.DataAnnotations.Schema;

namespace Dokaanah.Models
{
    public class Payment
    {

        public int Id { get; set; }
        public float Amount { get; set; }  ///Total price that will be Paid by Customer
        public string Method { get; set; }  //visa , paymobe , cash 


        [ForeignKey("Customer")]
        public string? Customerid { get; set; }
        public virtual Customer? Customer { get; set; } = null!;


       
    }
}
