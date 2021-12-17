using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconWebApp.Models
{
    public class CountryModel
{

        [Key]
        [DisplayName("Country Id")]
        public int CountryId { get; set; }

        [Required]
        [DisplayName("Country Name")]
        [MaxLength(50, ErrorMessage = "Country name with max 50 character")]
        public String CountryName { get; set; }


        public List<CityModel> Cities { get; set; }

    }
}
