using LexiconWebApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconWebApp.Models
{
    public class PersonModelRepo : IPersonModelRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public PersonModelRepo (ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IEnumerable<PersonModel> GetAllPerson
        {
            get
            {
                return _applicationDbContext.People.Include(person => person.City)
                .Where(person => person.CityId == person.City.CityId).ToList();
            }
        }

        public PersonModel GetPersonById(int personId)
        {
            return _applicationDbContext.People.FirstOrDefault(p => p.PersonId == personId);

        }

       


    }
}
