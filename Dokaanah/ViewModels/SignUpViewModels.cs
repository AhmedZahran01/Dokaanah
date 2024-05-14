using Dokaanah.Models;
using System.ComponentModel.DataAnnotations;

namespace Dokaanah.ViewModels
{
	public class SignUpViewModels
	{
		[Required(ErrorMessage = "User Name is Required")]
		public string UserName { get; set; }

		[Required(ErrorMessage ="Email is Required")]
		[EmailAddress(ErrorMessage = " Invalid Email ")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Password is Required")]
		[MinLength(5,ErrorMessage = "minmum Password is Required")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "confirm Password is Required")]
		[Compare(nameof(Password) ,ErrorMessage = "confirm Password does not match Password")]
		[DataType(DataType.Password)]
		public string confirmPassword { get; set; }


		public bool IsAgree { get; set; }


	}
}
