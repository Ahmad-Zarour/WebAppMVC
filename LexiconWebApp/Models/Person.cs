using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconWebApp.Models
{
    public class Person
    {
        private readonly int _id;
        public int Id { get { return _id; } }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }

        public Person()
        {

        }
        public Person(int id ,string name , string phoneNumber , string city)
        {
            this._id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            City = city;
        }
    }
}
