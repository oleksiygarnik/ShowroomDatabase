using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseCar.Data_Access_Layer.Entities
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public string Passport { get; set; }

        public DateTime BirthdayDate { get; set; }

        public int Age { get; set; }

        public int? ContactInfoId { get; set; }
        public ContactInfo ContactInfo { get; set; }


        public Person()
        {
        }
    }
}
