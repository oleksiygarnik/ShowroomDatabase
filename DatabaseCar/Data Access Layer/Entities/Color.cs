using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseCar.Data_Access_Layer.Entities
{
    public class Color
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Car> Cars { get; set; }

        public Color()
        {
            Cars = new List<Car>();
        }

    }
}
