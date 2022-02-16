using LexiconWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconWebApp.ViewModels
{
    public class CityViewModel
    {
        public IEnumerable<CountryModel> Countries { get; set; }
        public IEnumerable<CityModel> Cities { get; set; }
        
    }
}
