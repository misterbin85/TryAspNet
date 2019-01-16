using System.ComponentModel.DataAnnotations;

namespace CustomAuthenticationMVC.Models
{
	public class LoginView
	{
		[Required]
		[Display(Name = "User Name")]
		public string UserName { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[Display(Name = "Remember Me")]
		public bool RememberMe { get; set; }
	}
}