using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LexiconWebApp.Models
{
    //The Create PersonViewModel do the business logic since no need to add a Personrepository for example
    public class CreatePersonViewModel
    {
        private static List<Person> _personList = new List<Person>();
        private static int _idCounter = 1;
        

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter the person name."), MaxLength(25), MinLength(4)]
        [Display(Name = "Person Name")]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter the phone number."), MaxLength(12), MinLength(10)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter the city."), MaxLength(24), MinLength(3)]
        [Display(Name = "City")]
        public string City { get; set; }

        // create a MockPersonRepo
        public void MockPersonRepo()
        {
            CreatePersonViewModel newPerson = new CreatePersonViewModel();
            newPerson.CreatePerson("Sami", "+469564555", "Vänersborg");
            newPerson.CreatePerson("Johan", "+46956001", "Trollhättan");
            newPerson.CreatePerson("Jim", "+479777755", "Oslo");
        }

        public Person CreatePerson(string name, string phoneNumber, string city)
        {
            Person person = new Person(_idCounter, name, phoneNumber, city);
            _personList.Add(person);
            _idCounter++;
            return person;
        }

        public bool  DeletePerson(Person person)
        {
            bool status = _personList.Remove(person);
            return status;
        }

        public List<Person> GetListPerson()
        {
            return _personList;
        }

        public Person GetPersonById(int id)
        {
            Person personWithId = _personList.Find(p => p.Id == id);
            //if (personWithId == null)
            //    throw new ArgumentOutOfRangeException();
            return personWithId;
        }
    }
}
