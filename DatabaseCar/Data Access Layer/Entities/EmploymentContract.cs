using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseCar.Data_Access_Layer.Entities.Enums;

namespace DatabaseCar.Data_Access_Layer.Entities
{
    public class EmploymentContract
    {
        public int Id { get; set; }

        public decimal Salary { get; set; }

        public DateTime EmploymentDate { get; set; }

        public int? PositionId { get; set; }
        public Position Position { get; set; }
        
        public IEnumerable<Employee> Employees { get; set; }


        public EmploymentContract()
        {
            Employees = new List<Employee>();
        }
    }
}
