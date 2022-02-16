using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconWebApp.Models
{
    public class CityModel
{
		[Key]
		[DisplayName("City Id")]

		public int CityId { get; set; }


		[Required]
		[DisplayName("City Name")]
		[MaxLength(50, ErrorMessage = "City name with max 50 character")]
		public string CityName { get; set; }

		[Required]
		[ForeignKey("CountryId")]

		[DisplayName("Country Id")]
		public int CountryId { get; set; }

		public CountryModel Country { get; set; }
		public List<PersonModel> PeopleList { get; set; }
	
	}
	
}
