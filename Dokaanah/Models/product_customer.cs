using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dokaanah.Models
{
   
    public class product_customer
    {

        public string CustId { get; set; }
        public int PrudId { get; set; }
        public string? Comment { get; set; }
        [Range(0, 5, ErrorMessage = "Rating is from 0 to 5 only!")]
        public int? Rating { get; set; }

        public virtual Product? Prud { get; set; } = null!;   
        public virtual Customer? Cust { get; set; } = null!;


    }
}
