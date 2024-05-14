using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dokaanah.Models
{
    public class Customer:IdentityUser
    {
        
        public string? Name { get; set; }
		
		[Required(ErrorMessage = "Password is Required")]
		[MinLength(5, ErrorMessage = "minmum Password is Required")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "confirm Password is Required")]
		[Compare(nameof(Password), ErrorMessage = "confirm Password does not match Password")]
		[DataType(DataType.Password)]
		public string? confirmPassword { get; set; }
		
		public int? PhoneNumber { get; set; }
        public string? Address { get; set; }
		public bool? isAgree { get; set; }

		public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public virtual ICollection<product_customer> Product_Customelrs { get; set; } = new List<product_customer>();


    }
}
