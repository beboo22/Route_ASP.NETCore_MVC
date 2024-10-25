using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev._1stproj.DAL.Models.identity
{
    public class User : IdentityUser<int>
    {
        public string FName { get; set; } = null!;
        public string LName { get; set; } = null!;
        public bool RememberMe { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        //public string Password { get; set; } = null!;

        //[Required]
        //[DataType(DataType.Password)]
        //[Compare("Password",ErrorMessage = "The password and confirmation password do not match.")]
        //public string confirmPasswpr { get; set; } = null!;
    }
	public class Role : IdentityRole<int>
	{
		// Add any additional properties for roles if necessary
	}
}
