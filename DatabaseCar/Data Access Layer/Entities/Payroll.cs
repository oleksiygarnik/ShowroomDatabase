using DatabaseCar.Data_Access_Layer.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseCar.Data_Access_Layer.Entities
{
    public class Payroll
    {
        public int Id { get; set; }

        ////public int? BookkeeperId { get; set; }
        ////public Employee Bookkeeper { get; set; }


        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public DateTime Date { get; set; }
        
        //???????????????????????????????//
        public string PeriodDate { get; set; }

        public decimal Salary { get; set; }

        public Status Status { get; set; }
    }
}
