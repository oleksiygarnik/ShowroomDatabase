using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseCar.Data_Access_Layer.Entities
{
    public class ContactInfo
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public IEnumerable<Person> People { get; set; }

        public ContactInfo()
        {
            People = new List<Person>();
        }
    }
}
