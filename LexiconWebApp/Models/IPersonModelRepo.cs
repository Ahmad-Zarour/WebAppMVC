using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconWebApp.Models
{
    public interface IPersonModelRepo
    {
        IEnumerable<PersonModel> GetAllPerson { get; }
        PersonModel GetPersonById(int personId);

    }
}
