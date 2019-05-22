using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseCar.Data_Access_Layer.Entities
{
    public class Position
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<EmploymentContract> EmploymentContracts { get; set; }

        public IEnumerable<Table> Tables { get; set; }

        public Position()
        {
            Tables = new List<Table>();
            EmploymentContracts = new List<EmploymentContract>();
        }
    }
}
