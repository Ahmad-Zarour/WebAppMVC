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
		[Required]
		[DisplayName("First Name")]
		public string FirstName { get; set; }

		[Required]
		[DisplayName("Last Name")]
		public string LastName { get; set; }

		[Required]
		[DataType(DataType.Date)]
		[DisplayName("Birth Date")]
		public DateTime BirthDate { get; set; }
	}
}