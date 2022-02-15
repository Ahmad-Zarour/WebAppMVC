using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconWebApp.Models
{
    public class PersonModel
{
        [Key]
        [DisplayName("Person Id")]

        public int PersonId { get; set; }

        [Required]
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [Required]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }



        [DisplayName("City Id")]
       
        public int CityId { get; set; }
        public CityModel City { get; set; }

        public List<PersonLanguageModel> Person_Language { get; set; }
    }
}
