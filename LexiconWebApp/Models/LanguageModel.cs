using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconWebApp.Models
{
    public class LanguageModel
{
		[Key]
		[DisplayName("Language Id")]
		public int LanguageId { get; set; }

		[Required]
		[DisplayName("Language Name")]
		[MaxLength(50,ErrorMessage ="Language name with max 50 character")]
		public string LanguageName { get; set; }

		public List<PersonLanguageModel> Person_Language { get; set; }
	}
}
