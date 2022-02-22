using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconWebApp.Models
{
	public class ApplicationUser : IdentityUser
	{
		[Required(ErrorMessage = "Please enter your first name")]
		[DisplayName("First Name")]
		[StringLength(50)]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Please enter your last name")]
		[DisplayName("Last Name")]
		[StringLength(50)]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Please enter your birth date")]
		[DataType(DataType.Date)]
		[DisplayName("Birth Date")]
		public DateTime BirthDate { get; set; }


	
		[DisplayName("Is Admin")]
		public bool UserTypes { get; set; }


	}
}