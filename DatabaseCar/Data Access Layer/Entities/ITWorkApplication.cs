using DatabaseCar.Data_Access_Layer.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseCar.Data_Access_Layer.Entities
{


    public class ITWorkApplication
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public StatusIT Status { get; set; }

        public string Problem { get; set; }

        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public ITWorkApplication()
        {

        }
    }
}
