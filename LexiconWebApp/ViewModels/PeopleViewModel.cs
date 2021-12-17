using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconWebApp.Models
{
    public class PeopleViewModel : CreatePersonViewModel
    {
        public List<PersonModel> PeopleListViewModel { get; set; }
        public string Filter { get; set; }



        public PeopleViewModel()



        {
            PeopleListViewModel = new List<PersonModel>();
        }
    }
}
