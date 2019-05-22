using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseCar.Data_Access_Layer.Entities
{
    public class Command
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public DateTime Date { get; set; }

        public Command() { } 
    }
}
