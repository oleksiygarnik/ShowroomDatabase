using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseCar.Data_Access_Layer.Entities
{
    public class Table
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? PositionId { get; set; }
        public Position Position { get; set; }
    }
}
