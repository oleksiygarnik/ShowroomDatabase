using DatabaseCar.Data_Access_Layer.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseCar.Data_Access_Layer.Entities
{
    public class SickLeave
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Status Status { get; set; }

        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public SickLeave()
        {

        }
    }
}
