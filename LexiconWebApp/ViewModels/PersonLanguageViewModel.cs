using LexiconWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconWebApp.ViewModels
{
    public class PersonLanguageViewModel
    {
        public IEnumerable<PersonModel> People { get; set; }
        public IEnumerable<LanguageModel> Languages { get; set; }
        public IEnumerable<PersonLanguageModel> PeopleLanguages { get; set; }
    }
}
