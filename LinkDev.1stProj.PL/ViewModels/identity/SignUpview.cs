using System.ComponentModel.DataAnnotations;

namespace LinkDev._1stProj.PL.ViewModels.identity
{
	public class SignUpview
	{

		public string Username { get; set; } = null!;
		public string FName { get; set; } = null!;
		public string LName { get; set; } = null!;
		[EmailAddress]
		public string Email { get; set; } = null!;
		public bool RememberMe { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; } = null!;


		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; } = null!;
	}
}
