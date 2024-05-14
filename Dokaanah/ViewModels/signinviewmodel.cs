using System.ComponentModel.DataAnnotations;

namespace Dokaanah.ViewModels
{
    public class signinviewmodel
    {

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = " Invalid Email ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [MinLength(5, ErrorMessage = "minmum Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RemmeberMe { get; set; } = false;

    }
}
